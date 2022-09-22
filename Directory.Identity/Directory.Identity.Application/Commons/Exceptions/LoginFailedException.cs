namespace Directory.Identity.Application.Commons.Exceptions;

public class LoginFailedException : ApiException
{
    public LoginFailedException()
        : base(ApiErrorCode.LoginFailed, "Login failed! Check your username and password.") { }
}