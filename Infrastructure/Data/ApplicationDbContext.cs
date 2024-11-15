using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ScheduleDetail> ScheduleDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId);

            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);

            builder.Entity<User>()
               .HasMany(s => s.Schedule)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade); // Optional: Configure cascade delete if needed

            builder.Entity<Appointment>()
                .HasOne(a => a.Slot)
                .WithOne()
                .HasForeignKey<Appointment>(a => a.slotId)
                .OnDelete(DeleteBehavior.Restrict);  // Optional: Prevent cascade delete if needed


        }
    }

}