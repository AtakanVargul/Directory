using Directory.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Directory.Identity.Infrastructure.Persistence.Configurations;

public class AddressBookConfiguration : IEntityTypeConfiguration<AddressBook>
{
    public void Configure(EntityTypeBuilder<AddressBook> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Firm).HasMaxLength(50);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(100);

        builder.Ignore(u => u.DomainEvents);
    }
}