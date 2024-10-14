using Domain.Dtos.Appointment;
using Domain.Results;

namespace Application.Contracts
{
    public interface IAppointmentService
    {
        Task<Response<GetAppointmentResponse>> Add(AddAppointmentRequest request);
        Task<Response<GetAppointmentResponse[]>> GetAll();
        Task<Response<GetAppointmentResponse>> Get(int appointmentId);
        Task<Response<string>> AcceptAppointment(int appointmentId);
        Task<Response<string>> RejectAppointment(int appointmentId);
        Task<Response<string>> CancelAppointment(int appointmentId);
        Task<Response<GetAppointmentResponse>> Reschedule(int appointmentId, RescheduleAppointmentRequest request);
        Task<Response<GetAppointmentResponse>> ChangeDoctor(int appointmentId, ChangeAppointmentDoctorRequest request);
    }
}
