using Domain.Entities.AppointmentEntities;
using Domain.Entities.TimeSlotEntity;

namespace Domain.Entities.Lookups
{
    public class AppointmentStatus : Lookup
    {
        public virtual IEnumerable<Appointment>? Appointments { get; set; }
    }
}
