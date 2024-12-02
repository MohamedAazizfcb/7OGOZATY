using Domain.Entities.InsuranceProviderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations.InsuranceProviderConf
{
    public class InsuranceProviderConfiguration : IEntityTypeConfiguration<UserInsuranceProvider>
    {
        public void Configure(EntityTypeBuilder<UserInsuranceProvider> builder)
        {
            builder.HasKey(ip => ip.Id);

            builder.Property(ip => ip.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(ip => ip.ContactInfo)
                   .HasMaxLength(500);

            builder.Property(ip => ip.Notes)
                   .HasMaxLength(1000);

            builder.HasMany(ip => ip.Patients)
                   .WithOne(p => p.InsuranceProvider)
                   .HasForeignKey(p => p.UserInsuranceProviderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
