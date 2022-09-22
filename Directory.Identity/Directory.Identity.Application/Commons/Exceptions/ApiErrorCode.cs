
namespace Directory.Identity.Application.Commons.Exceptions;

public class ApiErrorCode
{
    public const string InvalidNewPassword = "301";
    public const string InvalidOtp = "302";
    public const string InvalidRegister = "303";
    public const string InvalidNewEmail = "304";
    public const string InvalidKycLevel = "305";
    public const string LockedOut = "306";
    public const string LoginFailed = "307";
    public const string PasswordExpired = "308";
    public const string PasswordsNotMatched = "309";
    public const string PasswordContent = "310";
    public const string PasswordLength = "311";
    public const string PasswordRepetitiveCharacter = "312";
    public const string PasswordSuccessiveCharacter = "313";
    public const string HasRelationalData = "314";
    public const string ForbiddenAgreementDocOperation = "315";
    public const string BirthdateOutOfRange = "316";
    public const string AlreadyInUse = "317";
}