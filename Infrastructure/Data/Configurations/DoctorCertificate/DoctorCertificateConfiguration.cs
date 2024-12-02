using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.DoctorCertificateEntity;

namespace Infrastructure.Data.Configurations.DoctorCertificateConf
{
    public class DoctorCertificateConfiguration : IEntityTypeConfiguration<DoctorCertificate>
    {
        public void Configure(EntityTypeBuilder<DoctorCertificate> builder)
        {
            // Primary Key
            builder.HasKey(dc => dc.Id);

            // Properties
            builder.Property(dc => dc.CertificateName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(dc => dc.IssuingAuthority)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(dc => dc.CertificateFilePath)
                   .HasMaxLength(250);

            builder.Property(dc => dc.IssuedDate)
                   .IsRequired();

            builder.Property(dc => dc.ExpiryDate)
                   .IsRequired(false);

            // Relationships
            builder.HasOne(dc => dc.Doctor)
                   .WithMany()
                   .HasForeignKey(dc => dc.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade); // Deletes certificates when the doctor is deleted
        }
    }
}
