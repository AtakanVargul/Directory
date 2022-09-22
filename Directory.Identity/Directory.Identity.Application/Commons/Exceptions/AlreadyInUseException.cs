
namespace Directory.Identity.Application.Commons.Exceptions;

public class AlreadyInUseException : ApiException
{
    public AlreadyInUseException()
        : base(ApiErrorCode.AlreadyInUse, $"Mail already taken!") { }
}