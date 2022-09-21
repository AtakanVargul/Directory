
namespace Directory.Identity.Application.Commons.Interfaces;

public interface IDomainEventService
{
    Task PublishAsync(DomainEvent domainEvent);
}
