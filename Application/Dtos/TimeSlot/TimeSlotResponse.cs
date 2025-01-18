using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Application.Dtos.TimeSlot
{
    public class TimeSlotResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; } // The specific date
        public TimeSpan StartTime { get; set; } // The start time of the available slot
        public TimeSpan EndTime { get; set; } // The end time of the available slot
        public int DoctorId { get; set; }
        public int TimeSlotStatusId { get; set; }
    }
}
