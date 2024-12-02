using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;

namespace Domain.Entities.FeedbackEntity
{
    public class Feedback
    {
        public int Id { get; set; } // Primary Key
        public int Rating { get; set; } // Rating out of 5
        public string Comment { get; set; } = string.Empty; // Feedback comment

        // Foreign Keys
        public int AppointmentId { get; set; } // Foreign Key to Appointment
        public virtual Appointment Appointment { get; set; }

        public int? DoctorId { get; set; } // Doctor Recieving feedback
        public virtual Doctor Doctor { get; set; }

        public int? PatientId { get; set; } // Patient Recieving feedback
        public virtual Patient Patient { get; set; }
    }

}
