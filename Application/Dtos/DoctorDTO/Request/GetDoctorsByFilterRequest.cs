using Domain.Entities.SpecializationServicesEntity;

namespace Application.Dtos.DoctorDTO.Request
{
    public class GetDoctorsByFilterRequest
    {
        public int? CountryId { get; set; }
        public int? GovernorateId { get; set; }
        public int? DistrictId { get; set; }
        public int? SpecializationId { get; set; }
        public int? MinimumCheckPrice { get; set; }
        public int? MaximumCheckPrice { get; set; }
    }
}
