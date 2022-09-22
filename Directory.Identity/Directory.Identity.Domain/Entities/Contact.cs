using System.ComponentModel.DataAnnotations.Schema;
using Directory.Identity.Application.Commons.Models.Persistence;

namespace Directory.Identity.Domain.Entities;

[Table("Contact", Schema = "Directory")]
public class Contact : AuditableEntity, ITrackChange
{
    public string PhoneNumber { get; set; }
    public string EmailAdress { get; set; }
    public Location Location { get; set; }
    public Guid? LocationId { get; set; }
}