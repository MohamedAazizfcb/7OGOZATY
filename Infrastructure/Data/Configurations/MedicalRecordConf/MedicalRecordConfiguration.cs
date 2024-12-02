using Domain.Entities.MedicalRecordEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations.MedicalRecordConf
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            // Primary Key
            builder.HasKey(mr => mr.Id);


            // Relationships
            builder.HasOne(mr => mr.Patient)
                   .WithOne(p => p.MedicalRecord)
                   .HasForeignKey<MedicalRecord>(mr => mr.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(mr => mr.Entries)
                   .WithOne(mre => mre.MedicalRecord)
                   .HasForeignKey(mre => mre.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a record deletes related entries
        }
    }
}
