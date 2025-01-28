
namespace Application.Dtos.SpecializationServices.Request
{
    public class SpecializationServiceRequest
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int AvgDurationInMinutes { get; set; }
        public int SpecializationId { get; set; }
    }
}
