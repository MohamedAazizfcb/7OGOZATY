using Domain.Entities.TimeSlotEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations.TimeSlotConf
{
    public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(ts => ts.Date).IsRequired();
            builder.Property(ts => ts.StartTime).IsRequired();
            builder.Property(ts => ts.EndTime).IsRequired();

            // Relationships
            builder.HasOne(ts => ts.Doctor)
                   .WithMany(d => d.TimeSlots)
                   .HasForeignKey(ts => ts.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ts => ts.TimeSlotStatus)
                   .WithMany(ts => ts.TimeSlots)
                   .HasForeignKey(ts => ts.TimeSlotStatusId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Optional relationship with Appointment
            builder.HasOne(ts => ts.Appointment)
                   .WithOne(a => a.TimeSlot)
                   .HasForeignKey<TimeSlot>(ts => ts.AppointmentId)
                   .OnDelete(DeleteBehavior.SetNull) // Allow the TimeSlot to remain unassigned
                   .IsRequired(false); // Make the relationship optional
        }
    }
}
