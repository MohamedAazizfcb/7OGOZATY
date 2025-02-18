namespace Application.Dtos.DoctorDTO.Response
{
    public class DoctorDayAppointmentsCountResponse
    {
        public int UpcominAppointmentsCount { get; set; }
        public int CancelledAppointmentsCount { get; set; }
        public int CompletedAppointmentsCount { get; set; }
    }
}
