using Domain.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LookupConfiguration<TLookup> : IEntityTypeConfiguration<TLookup> where TLookup : Lookup
{
    public void Configure(EntityTypeBuilder<TLookup> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name_Ar)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(l => l.Name_En)
            .IsRequired()
            .HasMaxLength(30);
    }
}
