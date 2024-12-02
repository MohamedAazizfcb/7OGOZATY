using Domain.Entities.ClinicEntity;
using Domain.Entities.FeedbackEntity;
using Domain.Entities.Lookups;
using Domain.Entities.TimeSlotEntity;
using Domain.Entities.User;

namespace Domain.Entities.AppointmentEntities
{
    public class Appointment
    {
        public int Id { get; set; } // Primary Key

        public DateTime AppointmentDate { get; set; } // Date of the appointment
        public string Notes { get; set; } = string.Empty; // Additional notes


        // Foreign Keys
        public int? TimeSlotId { get; set; } // Foreign Key to TimeSlot (nullable, as it may not be assigned)
        public virtual TimeSlot TimeSlot { get; set; } // Navigation Property

        public int? AppointmentStatusId { get; set; }
        public virtual AppointmentStatus AppointmentStatus { get; set; }

        public int? ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int? PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        // Feedbacks given on this appointment
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
