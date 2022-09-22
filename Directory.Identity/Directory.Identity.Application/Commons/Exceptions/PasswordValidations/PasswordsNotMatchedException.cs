
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class PasswordsNotMatchedException : ApiException
{
    public PasswordsNotMatchedException()
        : base(ApiErrorCode.PasswordsNotMatched, "Passwords not matched!") { }
}