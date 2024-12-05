using Domain.Entities.SpecializationServicesEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations.SpeicalizationServicesConf
{
    public class SpecializationServicesConfiguration : IEntityTypeConfiguration<SpecializationService>
    {
        public void Configure(EntityTypeBuilder<SpecializationService> builder)
        {
            // Primary Key configuration
            builder.HasKey(ss => ss.Id);

            // Properties configuration
            builder.Property(ss => ss.ServiceName)
                .IsRequired() // ServiceName is mandatory
                .HasMaxLength(255); // Set maximum length for ServiceName

            builder.Property(ss => ss.ServiceDescription)
                .HasMaxLength(1000); // Set maximum length for ServiceDescription

            builder.Property(ss => ss.AvgDurationInMinutes)
                .IsRequired(); // Ensure AvgDurationInMinutes is required

            // Foreign Key configuration for Specialization
            builder.HasOne(ss => ss.Specialization)
                .WithMany() // Assuming a specialization can have many services
                .HasForeignKey(ss => ss.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade); // Define delete behavior

            // Configure the one-to-many relationship between SpecializationService and DoctorServicePivot
            builder.HasMany(ss => ss.DoctorSpecializationsPivots) // One specialization service can have many doctor service pivots
                .WithOne() // Assuming DoctorServicePivot has a navigation property to SpecializationService
                .HasForeignKey(ds => ds.SpecializationServiceId) // Foreign key in DoctorServicePivot to SpecializationService
                .OnDelete(DeleteBehavior.Cascade); // Delete behavior for the related doctor service pivots when a SpecializationService is deleted

            builder.HasMany(a => a.AppointmentServicesPivots)
               .WithOne()
               .HasForeignKey(a => a.ServiceId)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
