using Domain.Entities.TimeSlotEntity;

namespace Domain.Entities.Lookups
{
    public class TimeSlotStatus : Lookup
    {
        public virtual ICollection<TimeSlot>? TimeSlots { get; set; }

    }
}
