using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Lookups;

namespace Infrastructure.Data.Configurations.LookupConf
{
    public class AppointmentStatusConfiguration : IEntityTypeConfiguration<AppointmentStatus>
    {
        public void Configure(EntityTypeBuilder<AppointmentStatus> builder)
        {
            builder.HasBaseType<Lookup>();

        }
    }
}
