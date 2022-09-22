
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class PasswordLengthException : ApiException
{
    public PasswordLengthException()
        : base(ApiErrorCode.PasswordLength, "Password must have 6 characters!") { }
}