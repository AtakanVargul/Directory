using Directory.Identity.Application.Commons.Models.AccountModels;
using Directory.Identity.Application.Features.Account.Commands.Login;
using Directory.Identity.Application.Features.Account.Commands.Register;
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
    public async Task<ActionResult<LoginResponse>> LoginAsync(LoginCommand command)
    {
        return await Mediator.Send(command);
    }
}