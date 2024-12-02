using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Users
{
    public class SecretaryConfiguration : IEntityTypeConfiguration<Secretary>
    {
        public void Configure(EntityTypeBuilder<Secretary> builder)
        {
            // Inherit IdentityUser configuration
            builder.HasBaseType<ApplicationUser>();

            builder.HasOne(s => s.Doctor)
               .WithMany()
               .HasForeignKey(s => s.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
