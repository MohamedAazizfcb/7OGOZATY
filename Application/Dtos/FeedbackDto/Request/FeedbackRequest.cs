using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;

namespace Application.Dtos.FeedbackDto.Request
{
    public class FeedbackRequest
    {
        public int Id { get; set; } // Primary Key
        public int Rating { get; set; } // Rating out of 5
        public string Comment { get; set; }

        // Foreign Keys
        public int AppointmentId { get; set; } // Foreign Key to Appointment
        public int DoctorId { get; set; } // Doctor Recieving feedback
        public int PatientId { get; set; } // Patient Recieving feedback
    }
}
