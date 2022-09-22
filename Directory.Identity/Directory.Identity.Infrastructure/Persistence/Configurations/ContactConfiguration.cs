using Directory.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Directory.Identity.Infrastructure.Persistence.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(u => u.EmailAdress).HasMaxLength(100);
        builder.Property(u => u.PhoneNumber).HasMaxLength(50);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(100);
    }
}