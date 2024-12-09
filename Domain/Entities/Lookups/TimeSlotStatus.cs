using Domain.Entities.TimeSlotEntity;

namespace Domain.Entities.Lookups
{
    public class TimeSlotStatus : Lookup
    {
        public virtual IEnumerable<TimeSlot>? TimeSlots { get; set; }

    }
}
