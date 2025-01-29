using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.SpecializationServicesEntity;

namespace Application.Dtos.SpecializationServices.Response
{
    public class SpecializationServiceResponse
    {
        public int Id { get; set; }
        public string ServiceDescription { get; set; }
        public int AvgDurationInMinutes { get; set; }
        // Foreign Keys
        public int SpecializationId { get; set; }
        public string ServiceName { get; set; }
    }
}
