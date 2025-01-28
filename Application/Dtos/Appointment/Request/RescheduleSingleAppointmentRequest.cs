namespace Application.Dtos.AppointmentDTO.Request
{
    public class RescheduleSingleAppointmentRequest
    {
        public int appointmentId { get; set; }
        public int newTimeSlotId { get; set; }
    }
}
