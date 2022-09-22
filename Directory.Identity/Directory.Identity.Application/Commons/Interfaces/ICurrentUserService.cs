namespace Directory.Identity.Application.Commons.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
}