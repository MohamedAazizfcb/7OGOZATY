using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Lookups;

namespace Infrastructure.Data.Configurations.LookupConf
{
    public class TimeSlotStatusConfiguration : IEntityTypeConfiguration<TimeSlotStatus>
    {
        public void Configure(EntityTypeBuilder<TimeSlotStatus> builder)
        {
            builder.HasBaseType<Lookup>();

        }

    }
}
