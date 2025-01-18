namespace Application.Dtos.TimeSlot
{
    public class TimeSlotRequest
    {
        public DateOnly Date { get; set; } // The specific date
        public TimeSpan StartTime { get; set; } // The start time of the available slot
        public TimeSpan EndTime { get; set; } // The end time of the available slot

        public int DoctorId { get; set; } // Foreign Key to Doctor

        public int TimeSlotStatusId { get; set; } // Foreign Key to TimeSlotStatus
    }
}
