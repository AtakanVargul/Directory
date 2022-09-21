using System.ComponentModel.DataAnnotations.Schema;
using Directory.Identity.Application.Commons.Models.Persistence;

namespace Directory.Identity.Domain.Entities;

[Table("Contact", Schema = "Identity")]
public class Contact : AuditableEntity, ITrackChange
{
}