using Domain.Entities.User;

namespace Domain.Entities.MedicalRecordEntities
{
    public class MedicalRecord
    {
        public int Id { get; set; } // Primary Key

        public int PatientId { get; set; } // Foreign Key to Patient
        public virtual Patient Patient { get; set; } // Navigation Property


        // Collection of MedicalRecordEntry
        public virtual ICollection<MedicalRecordEntry> Entries { get; set; }
    }
}
