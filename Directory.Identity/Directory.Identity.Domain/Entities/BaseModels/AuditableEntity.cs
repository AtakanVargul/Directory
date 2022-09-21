using System.ComponentModel.DataAnnotations;

namespace Directory.Identity.Application.Commons.Models.Persistence;

public class AuditableEntity : BaseEntity
{
    public DateTimeOffset CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }

    [MaxLength(50)]
    [Required]
    public string CreatedBy { get; set; }

    [MaxLength(50)]
    public string LastModifiedBy { get; set; }

    public RecordStatus RecordStatus { get; set; }
}