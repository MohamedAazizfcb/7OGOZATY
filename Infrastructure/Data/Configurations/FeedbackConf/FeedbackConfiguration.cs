using Domain.Entities.FeedbackEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations.FeedbackConf
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Rating)
                   .IsRequired();

            builder.Property(f => f.Comment)
                   .HasMaxLength(1000);

            // Foreign Key relationships
            builder.HasOne(f => f.Appointment)
                   .WithMany(a => a.Feedbacks) // An Appointment can have multiple feedbacks (doctor and patient)
                   .HasForeignKey(f => f.AppointmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Doctor)
                   .WithMany(d => d.FeedbackRecievedByMe) // Doctor can Recieve multiple feedbacks
                   .HasForeignKey(f => f.DoctorId)
                   .OnDelete(DeleteBehavior.SetNull); // If Doctor is deleted, set the feedback's doctor to null

            builder.HasOne(f => f.Patient)
                   .WithMany(p => p.FeedbackRecievedByMe) // Patient can Recieve multiple feedbacks
                   .HasForeignKey(f => f.PatientId)
                   .OnDelete(DeleteBehavior.SetNull); // If Patient is deleted, set the feedback's patient to null
        }
    }

}
