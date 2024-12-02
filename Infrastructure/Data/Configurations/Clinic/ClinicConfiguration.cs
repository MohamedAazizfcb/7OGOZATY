using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.ClinicEntity;

namespace Infrastructure.Data.Configurations.ClinicConf
{
    public class ClinicConfiguration:  IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Address)
                   .HasMaxLength(200);

            builder.Property(c => c.Phone)
                   .HasMaxLength(15);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.HasMany(c => c.Doctors)
                   .WithOne(d => d.Clinic)
                   .HasForeignKey(d => d.ClinicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Gallery)
                   .WithOne(d => d.Clinic)
                   .HasForeignKey(d => d.ClinicId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Appointments relationship
            builder.HasMany(d => d.Appointments)
                   .WithOne(a => a.Clinic)
                   .HasForeignKey(a => a.ClinicId)
                   .OnDelete(DeleteBehavior.SetNull); // Set to null if doctor is deleted
        }
    }
}
