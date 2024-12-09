using Domain.Entities.User;

namespace Domain.Entities.SpecializationServicesEntity
{
    public class DoctorServicePivot
    {
        public int DoctorPriceForService { get; set; }
        public int DoctorAvgDurationForServiceInMinutes { get; set; }

        // Foreign Keys
        public int SpecializationServiceId { get; set; }
        public virtual SpecializationService? SpecializationService { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
