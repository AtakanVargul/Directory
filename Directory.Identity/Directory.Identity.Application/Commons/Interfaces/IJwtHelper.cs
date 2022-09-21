using Directory.Identity.Domain.Entities;

namespace Directory.Identity.Application.Commons.Interfaces;

public interface IJwtHelper
{
    Task<string> GenerateJwtTokenAsync(User user, TimeSpan? expireIn = null);
}