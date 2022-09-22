namespace Directory.Identity.Application.Commons.Models.AccountModels;

public class RegisterResponse
{
    public string Token { get; set; }
    public Guid UserId { get; set; }
}