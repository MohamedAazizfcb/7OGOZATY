using Application.Dtos.AppointmentDTO.Response;

namespace Application.Dtos.DoctorDTO.Response
{
    public class DoctorDaySummaryResponse
    {
        public ICollection<AppointmentResponse> Appointments { get; set; }
        public int TotalDayRevenue { get; set; }
    }
}
