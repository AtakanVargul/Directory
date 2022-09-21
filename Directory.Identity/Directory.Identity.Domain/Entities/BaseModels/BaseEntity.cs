
namespace Directory.Identity.Application.Commons.Models.Persistence;

public class BaseEntity : IEntity<Guid>
{
    public Guid Id { get; set; } = SequentialGuid.NewSequentialGuid();
}