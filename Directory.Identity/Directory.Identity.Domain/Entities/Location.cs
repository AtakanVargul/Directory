using Directory.Identity.Application.Commons.Models.Persistence;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Identity.Domain.Entities;

[Table("Location", Schema = "Directory")]
public class Location : AuditableEntity
{
    public string Country { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Neighbourhood { get; set; }
    public string Street { get; set; }
    public string OpenAddress { get; set; }
    public string Zip { get; set; }
}