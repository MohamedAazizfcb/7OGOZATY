using Application.AppointmentDTO.Request;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.AppointmentDTO.Response;
using Domain.Results;

namespace Application.Contracts
{
    public interface IAppointmentService
    {
        Task<OperationResultSingle<string>> CreateAsync(CreateAppointmentRequest request);
        Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetAll();
        Task<OperationResultSingle<ICollection<AppointmentResponse>>> SearchForAppointments(SearchAppointmentsRequest request);
        Task<OperationResultSingle<AppointmentResponse>> GetById(int id);

        Task<OperationResultSingle<string>> RescheduleAppointment(RescheduleSingleAppointmentRequest request);
        Task<OperationResultSingle<string>> RescheduleDayOfAppointments(RescheduleDayOfAppointmentsRequest request);

        Task<OperationResultSingle<AppointmentResponse?>> ChangeAppointmentStatus(int appointmentId, int newStatusId);

        Task<OperationResultSingle<string>> DeleteAsync(int id);
        Task<OperationResultSingle<ICollection<AppointmentResponse>>> GetPendingAppointmentsOfDoctor(int docId);
        Task<OperationResultSingle<string>> AddServiceForAppointment(AddServiceForAppointmentRequest request);
        Task<OperationResultSingle<ICollection<AppointmentServicesResponse>>> GetAppointmentServices(int appointmentId);




    }
}
