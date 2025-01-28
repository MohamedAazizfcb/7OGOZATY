namespace Application.Dtos.TimeSlot
{
    public class CreateTimeSlotsOfIntervalRequest
    {
        public DateOnly IntervalDate { get; set; } // The specific date
        public TimeOnly IntervalStartTime { get; set; } // The start time of the available slot
        public TimeOnly IntervalEndTime { get; set; } // The end time of the available slot
        public int IntervalPeriod { get; set; }
        public int DoctorId { get; set; } // Foreign Key to Doctor
    }
}