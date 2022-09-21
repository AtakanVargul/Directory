
namespace Directory.Identity.Application.Commons.Exceptions;

public class ErrorCode
{
    public const string InternalError = "100";
    public const string ServiceForbidden = "101";
    public const string InvalidParameters = "102";
    public const string NotFound = "103";
    public const string ValidationError = "104";
    public const string InvalidCredentials = "105";
    public const string InvalidPermissions = "106";
    public const string DuplicateRecord = "107";
    public const string AlreadyInUse = "108";
    public const string InvalidAuthorizationHeader = "109";
    public const string AuthorizationSignatureMismatch = "110";
    public const string AuthorizationTimestampExpired = "111";
    public const string AuditableMissingInfo = "112";
}