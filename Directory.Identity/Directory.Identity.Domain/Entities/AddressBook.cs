using System.ComponentModel.DataAnnotations.Schema;
using Directory.Identity.Application.Commons.Models.Persistence;
using Directory.Identity.Domain.DomainEvents;

namespace Directory.Identity.Domain.Entities;

[Table("AddressBook", Schema = "Directory")]
public class AddressBook : AuditableEntity, ITrackChange, IHasDomainEvent
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Firm { get; set; }
    public Contact Contact { get; set; }
    public Guid ContactId { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new();
}