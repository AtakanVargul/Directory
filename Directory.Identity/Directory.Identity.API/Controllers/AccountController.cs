using Microsoft.AspNetCore.Mvc;

namespace Directory.Identity.API.Controllers;

public class AccountController : ApiControllerBase
{

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> RegisterAsync(RegisterCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> LoginAsync(LoginUserCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPost("reset-password")]
    public async Task ResetPasswordAsync(ResetPasswordCommand command)
    {
        await Mediator.Send(command);
    }
}