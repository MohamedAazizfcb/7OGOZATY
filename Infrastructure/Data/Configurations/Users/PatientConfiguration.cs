using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Users
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Inherit IdentityUser configuration
            builder.HasBaseType<ApplicationUser>();

            // Relationships
            builder.HasOne(p => p.MedicalRecord)
                   .WithOne(mr => mr.Patient)
                   .HasForeignKey<Patient>(p => p.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a patient deletes the medical record

            builder.HasOne(p => p.InsuranceProvider)
                   .WithMany(ip => ip.Patients)
                   .HasForeignKey(p => p.UserInsuranceProviderId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Properties
            builder.Property(p => p.EmergencyContactName)
                   .HasMaxLength(100);

            builder.Property(p => p.EmergencyContactPhone)
                   .HasMaxLength(15);

            builder.Property(p => p.BloodType)
                   .HasMaxLength(5);

            builder.Property(p => p.Notes)
                   .HasMaxLength(1000);


            builder.Property(p => p.InsurancePolicyNumber)
                   .HasMaxLength(20);

            // Appointments relationship
            builder.HasMany(d => d.Appointments)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientID)
                   .OnDelete(DeleteBehavior.SetNull); // Set to null if doctor is deleted

            // FeedbackRecievedByMe (Patient receiving feedback from doctors)
            builder.HasMany(p => p.FeedbackRecievedByMe)
                   .WithOne(f => f.Patient)  // Each feedback is related to one patient
                   .HasForeignKey(f => f.PatientId)  // PatientId in Feedback entity
                   .OnDelete(DeleteBehavior.SetNull);  // In case patient is deleted, don't delete the feedback


        }
    }
}
