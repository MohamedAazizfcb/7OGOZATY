using Application.Dtos.Clinic;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;
using Domain.Results;

namespace Application.Contracts
{
    public interface IClinicService
    {
        Task<OperationResultSingle<string>> CreateAsync(ClinicRequest request);
        Task<OperationResultSingle<IEnumerable<ClinicResponse>>> GetAllAsync();
        Task<OperationResultSingle<ClinicResponse>> GetByIdAsync(int id);
        Task<OperationResultSingle<string>> UpdateAsync(int id, ClinicRequest request);
        Task<OperationResultSingle<string>> DeleteAsync(int id);
        Task<OperationResultSingle<IEnumerable<Doctor>>> GetClinicDoctors(int id);
        Task<OperationResultSingle<IEnumerable<Appointment>>> GetClinicAppointments(int id);
    }
}
