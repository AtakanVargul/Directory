using Directory.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Directory.Identity.Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasIndex(u => u.Country).IsUnique();
        builder.Property(u => u.City).HasMaxLength(50);
        builder.Property(u => u.State).HasMaxLength(50);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(100); 
        builder.Property(u => u.Street).HasMaxLength(50);
        builder.Property(u => u.Neighbourhood).HasMaxLength(50);
        builder.Property(u => u.Zip).HasMaxLength(50);
    }
}