using Domain.Entities.AppointmentEntities;
using Domain.Entities.TimeSlotEntity;

namespace Domain.Entities.Lookups
{
    public class AppointmentStatus : Lookup
    {
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
