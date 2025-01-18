using Application.Contracts;
using Application.Dtos.Clinic;
using Application.Dtos.TimeSlot;
using AutoMapper;
using Azure.Core;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.ClinicEntity;
using Domain.Entities.TimeSlotEntity;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Results;
using Infrastructure.Utility.FileHandler;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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


        public async Task<OperationResultSingle<string>> CreateNewTimeSlot(TimeSlotRequest request)
        {
            var repository = _unitOfWork.GetRepository<TimeSlot>();

            if (await IsOverlapping(request))
            {
                return _operationResultFactory.BadRequest<string>("There is an existing overlapping time slot.");
            }

            // Map and add the new time slot

            var slot = _mapper.Map<TimeSlot>(request);
            await repository.AddAsync(slot);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Done")!;
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
    }
}
