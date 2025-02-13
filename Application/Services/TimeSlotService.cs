using Application.Contracts;
using Application.Dtos.TimeSlot;
using Application.Dtos.TimeSlot.Request;
using Application.Dtos.TimeSlot.Response;
using AutoMapper;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.TimeSlotEntity;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Application.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IMapper _mapper;

        public TimeSlotService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _operationResultFactory = operationResultFactory;
            _mapper = mapper;
        }

        public async Task<OperationResultSingle<string>> CreateTimeSlotsOfInterval(CreateTimeSlotsOfIntervalRequest request)
        {
            if(request.IntervalDate < DateOnly.FromDateTime(DateTime.Now))
            {
                return _operationResultFactory.BadRequest<string>("Cannot create slots for older dates.");
            }
            var timeIntervalList = SplitTimeInterval(request.IntervalStartTime, request.IntervalEndTime, request.IntervalPeriodInMinutes);
            var singleRequestsList = new List<TimeSlotRequest>();
            for (var i = 0; i < request.NumberOfWeeksToRepeat; i++)
            {
                DateOnly date = DateOnly.FromDateTime(request.IntervalDate.ToDateTime(TimeOnly.MinValue).AddDays(i * 7));
                foreach (var timeInterval in timeIntervalList) {
                    var singleRequest = new TimeSlotRequest()
                    {
                        Date = date,
                        DoctorId = request.DoctorId,
                        StartTime = timeInterval.StartTime,
                        EndTime = timeInterval.EndTime,
                        TimeSlotStatusId = (int)TimeSlotStatusEnum.Free
                    };

                    if (await IsOverlapping(singleRequest))
                    {
                        return _operationResultFactory.BadRequest<string>("There is an existing overlapping time slot.");
                    }

                    singleRequestsList.Add(singleRequest);
                }
          
            }

            foreach (var singleRequest in singleRequestsList) { 
                await CreateSingleSlot(singleRequest);
            }

            return _operationResultFactory.Success(singleRequestsList.Count.ToString() + " slots are created successfully!");
        }


        public async Task<OperationResultSingle<string>> CreateNewTimeSlot(TimeSlotRequest request)
        {
            if (await IsOverlapping(request))
            {
                return _operationResultFactory.BadRequest<string>("There is an existing overlapping time slot.");
            }

            return await CreateSingleSlot(request);
        }

        public async Task<OperationResultSingle<ICollection<TimeSlotResponse>>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();

            var result = await repository.GetAllAsync(include: 
                q => q
                    .Include(t => t.Doctor)
                    .Include(t => t.TimeSlotStatus)
            );

            var mappedResult = _mapper.Map<ICollection<TimeSlotResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<TimeSlotResponse>> GetByIdAsync(int timeSlotId)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();
            Expression<Func<TimeSlot, object>>[] includes = [
                t => t.Doctor,
                t => t.TimeSlotStatus,
            ];

            var result = await repository.GetByIdAsync(timeSlotId, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<TimeSlotResponse>("The provided ID doesn't match any record!");
            }
            var mappedResult = _mapper.Map<TimeSlotResponse>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<string>> UpdateTimeSlotForDoctor(int timeSlotId, TimeSlotRequest request)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();

            if (await IsOverlapping(request, timeSlotId))
            {
                return _operationResultFactory.BadRequest<string>("There is an existing overlapping time slot.");
            }

            var oldEntity = await repository.GetByIdAsync(timeSlotId);
            if (oldEntity != null)
            {

                _mapper.Map(request, oldEntity); // Maps properties from newEntity to oldEntity

                await repository.UpdateAsync(timeSlotId, oldEntity);
                await _unitOfWork.SaveAsync();

                return _operationResultFactory.Success("Done!")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }

        public async Task<OperationResultSingle<string>> ChangeTimeSlotStatus(int timeSlotId, int newStatusId)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();
            var oldEntity = await repository.GetByIdAsync(timeSlotId);
            if (oldEntity != null)
            {
                oldEntity.TimeSlotStatusId = newStatusId;
                await repository.UpdateAsync(timeSlotId, oldEntity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success("Done!")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }


        public async Task<OperationResultSingle<ICollection<TimeSlotResponse>>> GetDectorTimeSlots(GetDoctorTimeSlostRequest request)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();

            var result = await repository.GetAllAsync(
                filter:
            t => 
                    t.DoctorId == request.DoctorId
                    && request.TimeSlotStatusId != null? t.TimeSlotStatusId == request.TimeSlotStatusId : true
                    && request.Date != null? t.Date == request.Date : true
                ,
                orderBy:
                    q => q
                        .OrderBy(t => t.Date)
                        .OrderBy(t => t.StartTime)
                , include:
                    q => q
                        .Include(t => t.Doctor)
                        .Include(t => t.TimeSlotStatus)
            );

            if (result != null)
            {
                var mappedResult = _mapper.Map<ICollection<TimeSlotResponse>>(result);
                return _operationResultFactory.Success(mappedResult)!;
            }

            else
            {
                return _operationResultFactory.NotFound<ICollection<TimeSlotResponse>>("The provided ID doesn't match any record!");

            }
        }
        public async Task<OperationResultSingle<Appointment>> GetSlotAppointment(int timeSlotId)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();
            Expression<Func<TimeSlot, object>>[] includes = [
                t => t.Appointment,
            ];

            var result = await repository.GetByIdAsync(timeSlotId, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<Appointment>("The provided ID doesn't match any record!");
            }
            return _operationResultFactory.Success(result.Appointment)!;
        }

        public async Task<OperationResultSingle<WorkingDaysOfDoctorResponse>> GetWorkingDaysOfDoctor(WorkingDaysOfDoctorRequest request)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();
            DateTime currentDate = DateTime.Now;
            DateOnly maxDate = DateOnly.FromDateTime(currentDate.AddDays(request.NumberOfRequiredDays));
            DateOnly minDate = DateOnly.FromDateTime(currentDate);

            var result = await repository.GetAllAsync(
                filter:
            t =>
                    t.DoctorId == request.DocId &&
                    t.Date >= minDate &&
                    t.Date <= maxDate
                ,
                orderBy:
                    q => q
                        .OrderBy(t => t.Date)                
            );

            if (result != null)
            {

                var mappedResult = new WorkingDaysOfDoctorResponse()
                {
                    WorkingDays = result.Select(p => p.Date).Distinct().ToList()
                };
                return _operationResultFactory.Success(mappedResult)!;
            }
            return _operationResultFactory.Success(new WorkingDaysOfDoctorResponse()
            {
                WorkingDays= new List<DateOnly>() 
            });
        }

        private async Task<bool> IsOverlapping(TimeSlotRequest request, int? SlotToUpdateId = null!)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();

            var existingSlots = await repository.GetAllAsync(
                filter: ts =>
                    ts.DoctorId == request.DoctorId &&
                    ts.Date == request.Date &&
                    ((request.StartTime >= ts.StartTime && request.StartTime < ts.EndTime) || // Overlaps start
                     (request.EndTime > ts.StartTime && request.EndTime <= ts.EndTime) ||   // Overlaps end
                     (request.StartTime <= ts.StartTime && request.EndTime >= ts.EndTime)) // Completely overlaps
            );

            if(SlotToUpdateId != null) // For Update only
            {
                if(existingSlots.Count() == 1 && existingSlots.FirstOrDefault().Id == SlotToUpdateId) // return false if it overlaps only with it self
                {
                    return false;
                }
            }
            if (existingSlots.Any())
            {
                return true;
            }
            return false;
        }
        private async Task<OperationResultSingle<string>> CreateSingleSlot(TimeSlotRequest request)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();

            // Map and add the new time slot

            var slot = _mapper.Map<TimeSlot>(request);
            await repository.AddAsync(slot);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Done")!;
        }

        private List<(TimeOnly StartTime, TimeOnly EndTime)> SplitTimeInterval(TimeOnly startTime, TimeOnly endTime, int intervalMinutes)
        {
            List<(TimeOnly StartTime, TimeOnly EndTime)> result = new List<(TimeOnly, TimeOnly)>();

            TimeOnly currentStart = startTime;
            while (currentStart < endTime)
            {
                // Calculate the end time for the current interval
                TimeOnly currentEnd = currentStart.AddMinutes(intervalMinutes);

                // Ensure that the end time does not go beyond the overall end time
                if (currentEnd > endTime)
                {
                    currentEnd = endTime;
                }

                // Add the pair (currentStart, currentEnd) to the result list
                result.Add((currentStart, currentEnd));

                // Move the start time to the next interval
                currentStart = currentEnd;
            }

            return result;
        }


    }
}
