using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Application.Dtos.TimeSlot
{
    public class WorkingDaysOfDoctorRequest
    {
        public int DocId { get; set; }
        public int NumberOfRequiredDays { get; set; }
    }
}