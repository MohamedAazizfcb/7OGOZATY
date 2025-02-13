
using Application.AppointmentDTO.Request;
using Application.Contracts;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.AppointmentDTO.Response;
using Application.Dtos.Clinic;
using Application.Dtos.SpecializationServices.Response;
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
using Domain.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IMapper _mapper;
        private readonly ITimeSlotService _timeSlotService;

        public AppointmentService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory, IMapper mapper, ITimeSlotService timeSlotService)
        {
            _unitOfWork = unitOfWork;
            _operationResultFactory = operationResultFactory;
            _mapper = mapper;
            _timeSlotService = timeSlotService;
        }

        public async Task<OperationResultSingle<string>> CreateAsync(CreateAppointmentRequest request)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            var appointment = _mapper.Map<Appointment>(request);

            if (! await IsTimeSlotFree(appointment.TimeSlotId))
            {
                return _operationResultFactory.BadRequest<string>("Slot Not Free");
            }

            await repository.AddAsync(appointment);
            await _unitOfWork.SaveAsync();
            await  _timeSlotService.ChangeTimeSlotStatus(appointment.TimeSlotId, (int)TimeSlotStatusEnum.Occupied);

            return _operationResultFactory.Success("Appointment #" + appointment.Id + " is created successfully!")!;
        }

        public async Task<OperationResultSingle<string>> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            var entity = await repository.GetByIdAsync(id);
            if (entity != null)
            {
                await repository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();
                await _timeSlotService.ChangeTimeSlotStatus(entity.TimeSlotId, (int)TimeSlotStatusEnum.Cancelled);
                return _operationResultFactory.Success("Done")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }

        public async Task<OperationResultSingle<AppointmentResponse>> GetById(int id)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            Expression<Func<Appointment, object>>[] includes = [
                a => a.Clinic,
                a => a.AppointmentStatus,
                a => a.AppointmentServicesPivots,
                a => a.Doctor,
                a => a.Patient,
                a => a.Feedbacks,
                a => a.MedicalRecordEntry,
                a => a.TimeSlot,
            ];

            var result = await repository.GetByIdAsync(id, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<AppointmentResponse>("The provided ID doesn't match any record!");
            }
            var mappedResult = _mapper.Map<AppointmentResponse>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetAll()
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(a => a.Clinic)
                    .Include(a => a.AppointmentStatus)
                    .Include(a => a.AppointmentServicesPivots)
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .Include(a => a.Feedbacks)
                    .Include(a => a.MedicalRecordEntry)
                    .Include(a => a.TimeSlot)
            );

            var mappedResult = _mapper.Map<ICollection<AppointmentResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<string>> RescheduleAppointment(RescheduleSingleAppointmentRequest request)
        {
            if (!await IsTimeSlotFree(request.newTimeSlotId))
            {
                return _operationResultFactory.BadRequest<string>("Slot Not Free");
            }
            var repository = _unitOfWork.GetRepository<Appointment>();

            var appointment = await repository.GetByIdAsync(request.appointmentId);
            if (appointment == null) {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }

            appointment.TimeSlotId = request.newTimeSlotId;
            await repository.UpdateAsync(appointment.Id, appointment);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Rescheduled Successfully!");
        }

        public Task<OperationResultSingle<string>> RescheduleDayOfAppointments(RescheduleDayOfAppointmentsRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<OperationResultSingle<ICollection<AppointmentResponse>>> SearchForAppointments(SearchAppointmentsRequest request)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(a => a.Clinic)
                    .Include(a => a.AppointmentStatus)
                    .Include(a => a.AppointmentServicesPivots)
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .Include(a => a.Feedbacks)
                    .Include(a => a.MedicalRecordEntry)
                    .Include(a => a.TimeSlot)
                ,
                filter:
                    a =>
                        request.AppointmentId == null? true : a.Id == request.AppointmentId &&
                        request.PatientID == null ? true : a.PatientID == request.PatientID &&
                        request.AppointmentStatusId == null ? true : a.AppointmentStatusId == request.AppointmentStatusId &&
                        request.AppointmentDate == null ? true : a.TimeSlot.Date == request.AppointmentDate &&
                        request.PatientMobileNumber == null ? true : a.Patient.PhoneNumber == request.PatientMobileNumber &&
                        request.ClinicId == null ? true : a.ClinicId == request.ClinicId &&
                        request.PatientFirstName == null? true : (
                            a.Patient.FirstName.Contains(request.PatientFirstName) 
                            || request.PatientFirstName.Contains(a.Patient.FirstName)
                        ) &&
                        request.PatientLastName == null ? true : (
                            a.Patient.LastName.Contains(request.PatientLastName)
                            || request.PatientLastName.Contains(a.Patient.LastName)
                        ) &&
                        request.DoctortFirstName == null ? true : (
                            a.Doctor.FirstName.Contains(request.DoctortFirstName)
                            || request.DoctortFirstName.Contains(a.Doctor.FirstName)
                        ) &&
                        request.DoctorLastName == null ? true : (
                            a.Doctor.LastName.Contains(request.DoctorLastName)
                            || request.DoctorLastName.Contains(a.Doctor.LastName)
                        )
            );
            var mappedResult = _mapper.Map<ICollection<AppointmentResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }
    
        private async Task<bool> IsTimeSlotFree(int timeSlotId)
        {
            var timeSlot = (await _timeSlotService.GetByIdAsync(timeSlotId)).Data;

            if (timeSlot?.TimeSlotStatusId != (int)TimeSlotStatusEnum.Free)
            {
                return false;
            }
            return true;
        }

        public async Task<OperationResultSingle<AppointmentResponse?>> ChangeAppointmentStatus(int appointmentId, int newStatusId)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();

            var appointment = await repository.GetByIdAsync(appointmentId);
            if (appointment == null)
            {
                return _operationResultFactory.NotFound<AppointmentResponse?>("The provided ID doesn't match any record!");
            }
            appointment.AppointmentStatusId = newStatusId;
            await repository.UpdateAsync(appointmentId, appointment);
            await _unitOfWork.SaveAsync();
            return _operationResultFactory.Success(_mapper.Map<AppointmentResponse?>(appointment));
        }

        public async Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetPendingAppointmentsOfDoctor(int docId)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(a => a.Clinic)
                    .Include(a => a.AppointmentStatus)
                    .Include(a => a.AppointmentServicesPivots)
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .Include(a => a.Feedbacks)
                    .Include(a => a.MedicalRecordEntry)
                    .Include(a => a.TimeSlot)
                    ,
                filter: 
                    a => a.Doctor.Id == docId && 
                         a.AppointmentStatus.Id == (int)AppointmentStatusEnum.UpComing

            );

            var mappedResult = _mapper.Map<ICollection<AppointmentResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<string>> AddServiceForAppointment(AddServiceForAppointmentRequest request)
        {
            var repository = _unitOfWork.GetRepository<AppointmentServicesPivot>();
            var ASP = new AppointmentServicesPivot()
            {
                ServiceId = request.ServieId,
                AppointmentId = request.AppointmentId,
                SingleServicePriceForAppointment = request.Price
            };

            await repository.AddAsync(ASP);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Done!")!;
        }

        public async Task<OperationResultSingle<ICollection<AppointmentServicesResponse>>> GetAppointmentServices(int appointmentId)
        {
            var repository = _unitOfWork.GetRepository<AppointmentServicesPivot>();
            var result = await repository.GetAllAsync(include:
                    q => q
                        .Include(a => a.Service)
                        ,
                    filter:
                        a => a.AppointmentId == appointmentId
            );
            if (result == null)
            {
                return _operationResultFactory.NotFound<ICollection<AppointmentServicesResponse>>("The provided ID doesn't match any record!");
            }
            var mappedResult = _mapper.Map<ICollection<AppointmentServicesResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }
    }
}