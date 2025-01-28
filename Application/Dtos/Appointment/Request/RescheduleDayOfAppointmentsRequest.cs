namespace Application.Dtos.AppointmentDTO.Request
{
    public class RescheduleDayOfAppointmentsRequest
    {
        public int drId { get; set; }
        public DateOnly oldDate { get; set; }
        public DateOnly newDate { get; set; }
    }
}
