
namespace Directory.Identity.Application.Commons.Exceptions.PasswordValidations;

public class PasswordRepetitiveCharacterException : ApiException
{
    public PasswordRepetitiveCharacterException()
        : base(ApiErrorCode.PasswordRepetitiveCharacter, "Password can not have repetitive characters!") { }
}