using Domain.Entities.SpecializationServicesEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations.SpeicalizationServicesConf
{
    public class DoctorServicesPivotConfiguration : IEntityTypeConfiguration<DoctorServicePivot>
    {
        public void Configure(EntityTypeBuilder<DoctorServicePivot> builder)
        {
            // Primary Key configuration
            builder.HasKey(dsp => new { dsp.DoctorId, dsp.SpecializationServiceId });  // Composite primary key

            // Properties configuration
            builder.Property(dsp => dsp.DoctorPriceForService)
                .IsRequired()  // This property is required
                .HasColumnType("int");  // Specify the data type

            builder.Property(dsp => dsp.DoctorAvgDurationForServiceInMinutes)
                .IsRequired()  // This property is required
                .HasColumnType("int");  // Specify the data type

            // Foreign Key configuration for SpecializationService
            builder.HasOne(dsp => dsp.SpecializationService)
                .WithMany(ss => ss.DoctorSpecializationsPivots)  // Assuming SpecializationService has a navigation property for DoctorServicePivots
                .HasForeignKey(dsp => dsp.SpecializationServiceId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete, if you delete a SpecializationService, delete associated DoctorServicePivots

            // Foreign Key configuration for Doctor
            builder.HasOne(dsp => dsp.Doctor)
                .WithMany(d => d.DoctorServicePivots)  // Assuming Doctor has a navigation property for DoctorServicePivots
                .HasForeignKey(dsp => dsp.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete, if you delete a Doctor, delete associated DoctorServicePivots
        }
    }
}