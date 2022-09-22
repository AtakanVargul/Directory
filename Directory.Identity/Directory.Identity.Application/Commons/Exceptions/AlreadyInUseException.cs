namespace Directory.Identity.Application.Commons.Exceptions;

public class AlreadyInUseException : ApiException
{
    public AlreadyInUseException(string userName)
        : base(ApiErrorCode.AlreadyInUse, $"\"{userName}\" already taken!") { }
}