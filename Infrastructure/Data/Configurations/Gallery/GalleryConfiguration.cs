using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configurations.Gallery
{
    public class GalleryConfiguration : IEntityTypeConfiguration<BaseGallery>
    {
        public void Configure(EntityTypeBuilder<BaseGallery> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(g => g.ImageDescription)
                   .HasMaxLength(250);
        }
    }
}
