using Application.Contracts;
using Application.Dtos.AppointmentDTO.Response;
using Application.Dtos.DoctorDTO.Request;
using Application.Dtos.DoctorDTO.Response;
using AutoMapper;
using Azure.Core;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.SpecializationServicesEntity;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Results;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _operationResultFactory = operationResultFactory;
            _mapper = mapper;
        }

        public async Task<OperationResultSingle<string>> AddServiceToDoctor(AddServiceToDoctorRequest request)
        {
            var repository = _unitOfWork.GetRepository<DoctorServicePivot>();
            var STD = _mapper.Map<DoctorServicePivot>(request);

            await repository.AddAsync(STD);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Done")!;
        }

        public async Task<OperationResultSingle<DoctorDaySummaryResponse>> GetDaySummary(DateOnly date,int doctorId)
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
                    .Include(a => a.TimeSlot),
                filter: a => a.DoctorId == doctorId && a.TimeSlot.Date == date
            );

            var appointmentsList = _mapper.Map<ICollection<AppointmentResponse>>(result);

            var totalRevenue = appointmentsList.Sum(
                a => a.AppointmentServicesPivots?.Sum(
                    p => p.SingleServicePriceForAppointment) ?? 0);

            var mappedResult = new DoctorDaySummaryResponse()
            {
                Appointments = appointmentsList,
                TotalDayRevenue = totalRevenue
            };
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<DoctorDayAppointmentsCountResponse>> GetDoctorDayAppointmentsCount(DoctorDayAppointmentsCountRequest request)
        {
            var repository = _unitOfWork.GetRepository<Doctor>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(u => u.Appointments),
                filter:
                    a =>
                        request.DocId == null ? true : request.DocId == a.Id
            );
            if (result.Any())
            {
                var appointments = result.ToList()[0].Appointments;
                var mappedResult = new DoctorDayAppointmentsCountResponse()
                {
                    UpcominAppointmentsCount = appointments.Count(a => a.AppointmentStatusId == (int)AppointmentStatusEnum.UpComing),
                    CancelledAppointmentsCount = appointments.Count(a => a.AppointmentStatusId == (int)AppointmentStatusEnum.Cancelled),
                    CompletedAppointmentsCount = appointments.Count(a => a.AppointmentStatusId == (int)AppointmentStatusEnum.Done),
                };
                return _operationResultFactory.Success(mappedResult)!;
            }
            else {
                return _operationResultFactory.NotFound<DoctorDayAppointmentsCountResponse>("Invalid Doctor ID");
            }
        }

        public async Task<OperationResultSingle<ICollection<DoctorResponse>>> GetDoctorsByOptionalParams(GetDoctorsByFilterRequest request)
        {
            var repository = _unitOfWork.GetRepository<Doctor>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(u => u.Gender)
                    .Include(u => u.Country)
                    .Include(u => u.Governorate)
                    .Include(u => u.District)
                    .Include(u => u.AccountStatus)
                    .Include(u => u.ApplicationRole)
                    .Include(a => a.Clinic)
                    .Include(a => a.Specialization),
                filter: 
                    a =>
                        request.CountryId == null? true : request.CountryId == a.CountryId &&
                        request.GovernorateId == null ? true : request.GovernorateId == a.GovernorateId &&
                        request.DistrictId == null ? true : request.DistrictId == a.DistrictId &&
                        request.SpecializationId == null ? true : request.SpecializationId == a.SpecializationId &&
                        request.MinimumCheckPrice == null ? true : request.MinimumCheckPrice <= a.CheckPrice &&
                        request.MaximumCheckPrice == null ? true : request.MaximumCheckPrice >= a.CheckPrice

            );

            var mappedResult = _mapper.Map<ICollection<DoctorResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ICollection<DoctorResponse>>> GetDoctorsBySpecializationId(int specializationid)
        {
            var repository = _unitOfWork.GetRepository<Doctor>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(u => u.Gender)
                    .Include(u => u.Country)
                    .Include(u => u.Governorate)
                    .Include(u => u.District)
                    .Include(u => u.AccountStatus)
                    .Include(u => u.ApplicationRole)
                    .Include(a => a.Clinic)
                    .Include(a => a.Specialization),
                filter: a => a.SpecializationId == specializationid
            );

            var mappedResult = _mapper.Map<ICollection<DoctorResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ICollection<DoctorResponse>>> GetOverallTopTenRatedDoctors()
        {
            var repository = _unitOfWork.GetRepository<Doctor>();
            var result = await repository.GetAllAsync(include:
                q => q
                    .Include(u => u.Gender)
                    .Include(u => u.Country)
                    .Include(u => u.Governorate)
                    .Include(u => u.District)
                    .Include(u => u.AccountStatus)
                    .Include(u => u.ApplicationRole)
                    .Include(a => a.Clinic)
                    .Include(a => a.Specialization),
                orderBy: a => a.OrderBy(t => t.FeedbackRecievedByMe.Average(z => z.Rating))
            );

            var mappedResult = _mapper.Map<ICollection<DoctorResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }
    }
}
