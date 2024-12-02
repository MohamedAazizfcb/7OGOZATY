using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.ClinicEntity;
using Infrastructure.Data.Configurations.Gallery;
using Domain.Entities;

namespace Infrastructure.Data.Configurations.ClinicConf
{
    public class ClinicGalleryConfigurations : IEntityTypeConfiguration<ClinicGallery>
    {
        public void Configure(EntityTypeBuilder<ClinicGallery> builder)
        {
            // Inherit IdentityUser configuration
            builder.HasBaseType<BaseGallery>();

            builder.HasOne(g => g.Clinic)
                   .WithMany(c => c.Gallery)
                   .HasForeignKey(g => g.ClinicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
