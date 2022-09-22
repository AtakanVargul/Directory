
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class InvalidRegisterException : ApiException
{
    public InvalidRegisterException()
        : base(ApiErrorCode.InvalidRegister, "InvalidRegisterException") { }
}