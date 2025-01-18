using Domain.Entities.User;

namespace Domain.Entities.DoctorCertificateEntity
{
    public class DoctorCertificate
    {
        public int Id { get; set; } // Primary Key

        public string CertificateName { get; set; } 
        public string IssuingAuthority { get; set; }
        public DateOnly IssuedDate { get; set; } // Date when the certificate was issued
        public DateOnly? ExpiryDate { get; set; } // Optional: Expiry date, if applicable
        public string CertificateFilePath { get; set; }

        // Relationship with Doctor
        public int DoctorId { get; set; } // Foreign Key
        public virtual Doctor Doctor { get; set; }
    }
}