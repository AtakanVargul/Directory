
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class PasswordExpiredException : ApiException
{
    public PasswordExpiredException()
        : base(ApiErrorCode.PasswordExpired, "Password has expired!") { }
}