using Domain.Entities.AppointmentEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.MedicalRecordEntities;

namespace Infrastructure.Data.Configurations.AppointmentConf
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AppointmentDate).IsRequired();
            builder.Property(a => a.Notes)
                   .HasMaxLength(1000)
                   .IsRequired(false); // Make notes optional

            builder.HasOne(a => a.TimeSlot) // One Appointment to one TimeSlot
               .WithOne(ts => ts.Appointment) // TimeSlot can be linked to at most one Appointment
               .HasForeignKey<Appointment>(a => a.TimeSlotId) // Foreign key property
               .OnDelete(DeleteBehavior.SetNull) // Set TimeSlotId to null if the Appointment is deleted
               .IsRequired(false); // TimeSlotId is optional


            builder.HasOne(a => a.AppointmentStatus)
                   .WithMany(aps => aps.Appointments)
                   .HasForeignKey(a => a.AppointmentStatusId)
                   .OnDelete(DeleteBehavior.SetNull) // Set to null if AppointmentStatus is deleted
                   .IsRequired(false); // AppointmentStatus is optional

            builder.HasOne(a => a.Clinic)
                   .WithMany(c => c.Appointments)
                   .HasForeignKey(a => a.ClinicId)
                   .OnDelete(DeleteBehavior.SetNull) // Allow Clinic to be null if deleted
                   .IsRequired(false); // Clinic is optional

            builder.HasOne(a => a.Doctor)
                   .WithMany(d => d.Appointments)
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.SetNull) // Set to null if Doctor is deleted
                   .IsRequired(false); // Doctor is optional

            builder.HasOne(a => a.Patient)
                   .WithMany(p => p.Appointments)
                   .HasForeignKey(a => a.PatientID)
                   .OnDelete(DeleteBehavior.SetNull) // Set to null if Patient is deleted
                   .IsRequired(false); // Patient is optional

            builder.HasMany(a => a.AppointmentServicesPivots)
                   .WithOne(s => s.Appointment)
                   .HasForeignKey(a => a.AppointmentId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(e => e.MedicalRecordEntry)
                  .WithOne(a => a.Appointment)
                  .HasForeignKey<Appointment>(mr => mr.Id)
                  .OnDelete(DeleteBehavior.Cascade); // Deleting a medical record deletes its entries


            // Feedback for Appointment
            builder.HasMany(a => a.Feedbacks)  // An appointment can have multiple feedback entries
                   .WithOne(f => f.Appointment)  // Each feedback is related to one appointment
                   .HasForeignKey(f => f.AppointmentId)  // Foreign Key in Feedback
                   .OnDelete(DeleteBehavior.Cascade);  // If an appointment is deleted, feedback should not be deleted
        }
    }
}