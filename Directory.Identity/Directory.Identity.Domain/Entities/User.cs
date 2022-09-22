
using Directory.Identity.Application.Commons.Models.Persistence;
using Directory.Identity.Domain.DomainEvents;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Identity.Domain.Entities;

[Table("User", Schema = "Identity")]
public class User : IdentityUser<Guid>, IHasDomainEvent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTimeOffset PasswordModifiedDate { get; set; }
    public RecordStatus RecordStatus { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new();

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}