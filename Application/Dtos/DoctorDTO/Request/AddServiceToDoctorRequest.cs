using Domain.Entities.SpecializationServicesEntity;

namespace Application.Dtos.DoctorDTO.Request
{
    public class AddServiceToDoctorRequest
    {
        public int DoctorPriceForService { get; set; }
        public int DoctorAvgDurationForServiceInMinutes { get; set; }
        public int SpecializationServiceId { get; set; }
        public int DoctorId { get; set; }
    }
}
