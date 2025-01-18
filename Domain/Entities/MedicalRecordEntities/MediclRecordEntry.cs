using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;

namespace Domain.Entities.MedicalRecordEntities
{
    public class MedicalRecordEntry
    {
        public int Id { get; set; } // Primary Key

        public int MedicalRecordId { get; set; } // Foreign Key
        public virtual MedicalRecord MedicalRecord { get; set; } = null!; // Navigation Property

        public DateTime EntryDate { get; set; } = DateTime.UtcNow; // Date of the entry
        public string Diagnosis { get; set; } = string.Empty; // Diagnosis details
        public string Treatment { get; set; } = string.Empty; // Treatment details
        public string Notes { get; set; } = string.Empty; // Additional notes
        public string Prescriptions { get; set; } = string.Empty; // Prescribed medicines

        public int AppointmentId { get; set; } // Foreign Key to Patient
        public virtual Appointment Appointment { get; set; } = null!; // Navigation Property

    }
}
