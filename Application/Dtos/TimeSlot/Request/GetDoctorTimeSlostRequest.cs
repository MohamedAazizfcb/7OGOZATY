namespace Application.Dtos.TimeSlot.Request
{
    public class GetDoctorTimeSlostRequest
    {
        public int DoctorId { get; set; }
        public int? TimeSlotStatusId { get; set; }
        public DateOnly? Date { get; set; }
    }
}