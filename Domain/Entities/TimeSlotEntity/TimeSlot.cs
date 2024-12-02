using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Domain.Entities.TimeSlotEntity
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } // The specific date
        public TimeSpan StartTime { get; set; } // The start time of the available slot
        public TimeSpan EndTime { get; set; } // The end time of the available slot

        // Foreign Keys
        public int DoctorId { get; set; } // Foreign Key to Doctor
        public virtual Doctor Doctor { get; set; } = null!;

        public int TimeSlotStatusId { get; set; } // Foreign Key to TimeSlotStatus
        public virtual TimeSlotStatus TimeSlotStatus { get; set; } = null!;


        // Foreign Key to Appointment (optional)
        public int? AppointmentId { get; set; } // Nullable Foreign Key to Appointment
        public virtual Appointment Appointment { get; set; } // Navigation Property

    }
}