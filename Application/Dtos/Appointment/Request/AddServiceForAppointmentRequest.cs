namespace Application.AppointmentDTO.Request
{
    public class AddServiceForAppointmentRequest
    {
        public int ServieId { get; set; }
        public int AppointmentId { get; set; }
        public int Price { get; set; }
    }
}
