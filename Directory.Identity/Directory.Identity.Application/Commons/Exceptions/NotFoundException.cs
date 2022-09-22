namespace Directory.Identity.Application.Commons.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException()
        : base(ApiErrorCode.NotFound, $"Data not found!") { }

    public NotFoundException(string name)
        : base(ApiErrorCode.NotFound, $"\"{name}\" not found!") { }
}