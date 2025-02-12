using Application.Dtos.DoctorDTO.Request;
using Application.Dtos.DoctorDTO.Response;
using Application.Dtos.TimeSlot;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Results;

namespace Application.Contracts
{
    public interface IDoctorService
    {
        Task<OperationResultSingle<string>> AddServiceToDoctor(AddServiceToDoctorRequest request);
        Task<OperationResultSingle<DoctorDaySummaryResponse>> GetDaySummary(DateOnly date, int doctorId);
        Task<OperationResultSingle<ICollection<DoctorResponse>>> GetDoctorsBySpecializationId(int specializationid);
        Task<OperationResultSingle<ICollection<DoctorResponse>>> GetOverallTopTenRatedDoctors();
        Task<OperationResultSingle<ICollection<DoctorResponse>>> GetDoctorsByOptionalParams(GetDoctorsByFilterRequest request);


    }
}
