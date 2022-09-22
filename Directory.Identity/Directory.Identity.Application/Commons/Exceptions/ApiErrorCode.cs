
namespace Directory.Identity.Application.Commons.Exceptions;

public class ApiErrorCode
{
    public const string InvalidRegister = "301";
    public const string AlreadyInUse = "302";
    public const string LoginFailed = "303";
    public const string PasswordExpired = "304";
    public const string PasswordsNotMatched = "305";
    public const string PasswordContent = "306";
    public const string PasswordLength = "307";
    public const string PasswordRepetitiveCharacter = "308";
    public const string PasswordSuccessiveCharacter = "309";
    public const string ValidationError = "310";
    public const string NotFound = "311";
    
}