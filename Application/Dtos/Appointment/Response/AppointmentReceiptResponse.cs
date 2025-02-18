namespace Application.Dtos.Appointment.Response
{
    struct ServicePricePairResponse
    {
        string ServiceName;
        string ServicePrice;
    }
    public class AppointmentReceiptResponse
    {
        public string PatientName { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        //public ICollection<ServicePricePairResponse> servicePricePairResponses { get; set; }
    }
}
