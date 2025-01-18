using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;

namespace Domain.Entities.SpecializationServicesEntity
{
    public class SpecializationService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int AvgDurationInMinutes { get; set; }


        // Foreign Keys
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; } = null!;

        public virtual ICollection<DoctorServicePivot>? DoctorSpecializationsPivots { get; set; } = new List<DoctorServicePivot>();
        public virtual ICollection<AppointmentServicesPivot>? AppointmentServicesPivots { get; set; } = new List<AppointmentServicesPivot>();

    }
}
