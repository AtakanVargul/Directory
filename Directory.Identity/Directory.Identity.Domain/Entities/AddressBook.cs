using System.ComponentModel.DataAnnotations.Schema;
using Directory.Identity.Application.Commons.Models.Persistence;

namespace Directory.Identity.Domain.Entities;

[Table("AddressBook", Schema = "Identity")]
public class AddressBook : AuditableEntity, ITrackChange
{
}