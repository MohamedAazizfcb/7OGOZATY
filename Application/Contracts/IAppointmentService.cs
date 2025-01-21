using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.AppointmentDTO;
using Application.Dtos.Clinic;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;
using Domain.Results;

namespace Application.Contracts
{
    public interface IAppointmentService
    {
        Task<OperationResultSingle<string>> CreateAsync(CreateAppointmentRequest request);
        Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetAll();
        Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetDoctorAppointments(int docId);
        Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetPatientAppointments(int patientId);
        Task<OperationResultSingle<AppointmentResponse>> GetById(int id);



        Task<OperationResultSingle<string>> UpdateAsync(int id, ClinicRequest request);
        Task<OperationResultSingle<string>> RescheduleAppointment(int id, ClinicRequest request);
        Task<OperationResultSingle<string>> RescheduleDayOfAppointments(int id, ClinicRequest request);

        Task<OperationResultSingle<string>> DeleteAsync(int id);
    }
}
