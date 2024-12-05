using Domain.Entities.MedicalRecordEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations.MedicalRecordConf
{
    public class MedicalRecordEntryConfiguration : IEntityTypeConfiguration<MedicalRecordEntry>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordEntry> builder)
        {
            // Primary Key
            builder.HasKey(e => e.Id);

            // Relationships
            builder.HasOne(e => e.MedicalRecord)
                   .WithMany(mr => mr.Entries)
                   .HasForeignKey(e => e.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a medical record deletes its entries

            builder.HasOne(e => e.Appointment)
                  .WithOne(a => a.MedicalRecordEntry)
                  .HasForeignKey<MedicalRecordEntry>(mr => mr.MedicalRecordId)
                  .OnDelete(DeleteBehavior.Cascade); // Deleting a medical record deletes its entries


            // Properties
            builder.Property(e => e.EntryDate)
                   .IsRequired();

            builder.Property(e => e.Diagnosis)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(e => e.Treatment)
                   .HasMaxLength(500);

            builder.Property(e => e.Notes)
                   .HasMaxLength(1000);

            builder.Property(e => e.Prescriptions)
                   .HasMaxLength(1000);
        }
    }
}
