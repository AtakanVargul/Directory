using Directory.Identity.Application.Commons.Models.Persistence;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Identity.Domain.Entities;

[Table("User", Schema = "Identity")]
public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public string LastModifiedBy { get; set; }
    public RecordStatus RecordStatus { get; set; }
    public AddressBook AddressBook { get; set; }
    public ICollection<AddressBook> AddressBooks { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}