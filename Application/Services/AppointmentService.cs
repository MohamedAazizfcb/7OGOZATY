using Application.Contracts;
using Application.Dtos.AppointmentDTO;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.Clinic;
using Application.Dtos.TimeSlot;
using AutoMapper;
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
            //var timeSlot = (await _timeSlotService.GetByIdAsync(appointment.TimeSlotId)).Data;

            //if(timeSlot?.TimeSlotStatusId != (int)TimeSlotStatusEnum.Free)
            //{
            //    return _operationResultFactory.BadRequest<string>("Slot Not Free");
            //}

            await repository.AddAsync(appointment);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Done")!;
        }

        public async Task<OperationResultSingle<string>> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Appointment>();
            var entity = await repository.GetByIdAsync(id);
            if (entity != null)
            {
                await repository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();
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

        public Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetDoctorAppointments(int docId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetPatientAppointments(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultSingle<string>> RescheduleAppointment(int id, ClinicRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultSingle<string>> RescheduleDayOfAppointments(int id, ClinicRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultSingle<string>> UpdateAsync(int id, ClinicRequest request)
        {
            throw new NotImplementedException();
        }
    }
}