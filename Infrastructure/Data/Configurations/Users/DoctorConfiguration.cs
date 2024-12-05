using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Users
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    { 
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // Inherit IdentityUser configuration
            builder.HasBaseType<ApplicationUser>();

            // Properties
            builder.Property(d => d.Brief)
                   .HasMaxLength(500); // Optional: Adjust based on requirements

            builder.Property(d => d.CertificateId)
                   .IsRequired(false);

            // Relationships
            builder.HasOne(d => d.Clinic)
                   .WithMany(c => c.Doctors)
                   .HasForeignKey(d => d.ClinicId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(d => d.Specialization)
                   .WithMany()
                   .HasForeignKey(d => d.SpecializationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.DoctorCertificates)
                   .WithOne(dc => dc.Doctor)
                   .HasForeignKey(dc => dc.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a doctor deletes related certificates

            // TimeSlots relationship
            builder.HasMany(d => d.TimeSlots)
                   .WithOne(ts => ts.Doctor)
                   .HasForeignKey(ts => ts.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade); // Cascade delete time slots if doctor is deleted

            // Appointments relationship
            builder.HasMany(d => d.Appointments)
                   .WithOne(a => a.Doctor)
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.SetNull); // Set to null if doctor is deleted

            // FeedbackRecievedByMe (Doctor receiving feedback from patients)
            builder.HasMany(d => d.FeedbackRecievedByMe)
                   .WithOne(f => f.Doctor)  // Each feedback is related to one doctor
                   .HasForeignKey(f => f.DoctorId)  // DoctorId in Feedback entity
                   .OnDelete(DeleteBehavior.SetNull);  // In case doctor is deleted, don't delete the feedback

            builder.HasMany(ss => ss.DoctorServicePivots) 
                .WithOne() 
                .HasForeignKey(ds => ds.DoctorId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
