using Directory.Identity.Application.Commons.Models.Persistence;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Identity.Domain.Entities;

[Table("Role", Schema = "Identity")]
public class Role : IdentityRole<Guid>
{
    public string Description { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public string LastModifiedBy { get; set; }
    public RecordStatus RecordStatus { get; set; }
}