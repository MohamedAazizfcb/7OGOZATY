using Domain.Dtos.Appointment;
using Domain.Results;

namespace Application.Contracts
{
    public interface IAppointmentService
    {
        Task<Response<GetAppointmentResponse>> Add(AddAppointmentRequest request);
        Task<Response<GetAppointmentResponse[]>> GetAll();
        Task<Response<GetAppointmentResponse>> Get(string appointmentId);
        Task<Response<string>> AcceptAppointment(string appointmentId);
        Task<Response<string>> RejectAppointment(string appointmentId);
        Task<Response<string>> CancelAppointment(string appointmentId);
        Task<Response<GetAppointmentResponse>> Reschedule(string appointmentId, RescheduleAppointmentRequest request);
        Task<Response<GetAppointmentResponse>> ChangeDoctor(string appointmentId, ChangeAppointmentDoctorRequest request);
    }
}
