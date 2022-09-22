
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class PasswordSuccessiveCharacterException : ApiException
{
    public PasswordSuccessiveCharacterException()
        : base(ApiErrorCode.PasswordSuccessiveCharacter, "Password can not have successive characters!") { }
}