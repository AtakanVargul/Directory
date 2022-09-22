
namespace Directory.Identity.Domain.DomainEvents;

public class UserCreatedEvent : DomainEvent
{
    public UserCreatedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}