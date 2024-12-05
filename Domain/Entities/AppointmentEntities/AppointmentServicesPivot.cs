using Domain.Entities.SpecializationServicesEntity;
using Domain.Entities.User;

namespace Domain.Entities.AppointmentEntities
{
    public class AppointmentServicesPivot
    {

        // Foreign Keys
        public int ServiceId { get; set; }
        public virtual SpecializationService Service { get; set; } = null!;

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; } = null!;
    }
}
