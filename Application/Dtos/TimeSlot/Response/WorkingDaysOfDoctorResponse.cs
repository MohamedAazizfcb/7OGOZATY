using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Application.Dtos.TimeSlot
{
    public class WorkingDaysOfDoctorResponse
    {
        public ICollection<DateOnly>WorkingDays { get; set; }
    }
}
