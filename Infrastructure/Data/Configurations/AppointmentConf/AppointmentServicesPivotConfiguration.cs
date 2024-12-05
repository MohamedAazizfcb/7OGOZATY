using Domain.Entities.SpecializationServicesEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.AppointmentEntities;

namespace Infrastructure.Data.Configurations.AppointmentConf
{
    public class AppointmentServicesPivotConfiguration : IEntityTypeConfiguration<AppointmentServicesPivot>
    {
        public void Configure(EntityTypeBuilder<AppointmentServicesPivot> builder)
        {
            // Primary Key configuration
            builder.HasKey(dsp => new { dsp.AppointmentId, dsp.ServiceId });  // Composite primary key




            // Foreign Key configuration for SpecializationService
            builder.HasOne(dsp => dsp.Service)
                .WithMany(ss => ss.AppointmentServicesPivots)  
                .HasForeignKey(dsp => dsp.ServiceId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Foreign Key configuration for Doctor
            builder.HasOne(dsp => dsp.Appointment)
                .WithMany(d => d.AppointmentServicesPivots) 
                .HasForeignKey(dsp => dsp.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
