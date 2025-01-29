using Domain.Entities.SpecializationServicesEntity;

namespace Application.Dtos.AppointmentDTO.Response
{
    public class AppointmentServicesResponse
    {
        public int ServiceId { get; set; }
        public string ServiceDescription { get; set; }
        public int AvgDurationInMinutes { get; set; }
        // Foreign Keys
        public string ServiceName { get; set; }
        public int SingleServicePriceForAppointment { get; set; }
    }
}
