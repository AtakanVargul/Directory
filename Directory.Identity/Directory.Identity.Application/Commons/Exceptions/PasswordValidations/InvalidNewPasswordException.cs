
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class InvalidNewPasswordException : ApiException
{
    public InvalidNewPasswordException()
        : base(ApiErrorCode.InvalidNewPassword, "Invalid new password!") { }
}