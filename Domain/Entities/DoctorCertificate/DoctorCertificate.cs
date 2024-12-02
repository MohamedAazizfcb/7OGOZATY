using Domain.Entities.User;

namespace Domain.Entities.DoctorCertificateEntity
{
    public class DoctorCertificate
    {
        public int Id { get; set; } // Primary Key

        public string CertificateName { get; set; } = string.Empty; // Name or Title of the Certificate
        public string IssuingAuthority { get; set; } = string.Empty; // Organization that issued the certificate
        public DateTime IssuedDate { get; set; } // Date when the certificate was issued
        public DateTime? ExpiryDate { get; set; } // Optional: Expiry date, if applicable
        public string CertificateFilePath { get; set; } = string.Empty; // Path to the certificate file

        // Relationship with Doctor
        public int DoctorId { get; set; } // Foreign Key
        public virtual Doctor Doctor { get; set; } = null!;
    }
}