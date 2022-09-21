using Directory.Identity.Application.Commons.Interfaces;

namespace Directory.Identity.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    public Guid UserId { get; }
}