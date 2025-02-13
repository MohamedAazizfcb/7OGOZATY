using Application.Dtos.TimeSlot.Response;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.FeedbackEntity;
using Domain.Entities.MedicalRecordEntities;

namespace Application.Dtos.AppointmentDTO.Response
{
    public class AppointmentResponse
    {
        public int Id { get; set; } // Primary Key

        public string Notes { get; set; }


        public virtual TimeSlotResponse TimeSlot { get; set; } // Navigation Property

        public int AppointmentStatusId { get; set; }

        public string AppointmentStatus_Ar { get; set; }
        public string AppointmentStatus_En { get; set; }

        public int? ClinicId { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialization_En { get; set; }
        public string DoctorSpecialization_Ar { get; set; }


        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public virtual ICollection<AppointmentServicesPivot>? AppointmentServicesPivots { get; set; }

        public int MedicalRecordEntryId { get; set; } // Foreign Key to Patient
        public virtual MedicalRecordEntry MedicalRecordEntry { get; set; } = null!; // Navigation Property

        // Feedbacks given on this appointment
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
    }
}
