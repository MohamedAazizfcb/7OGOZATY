using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public User Patient { get; set; }
        public string DoctorId { get; set; }
        public User Doctor { get; set; }
        public string slotId { get; set; }  // Foreign key
        public ScheduleDetail Slot { get; set; }  // Navigation property
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
