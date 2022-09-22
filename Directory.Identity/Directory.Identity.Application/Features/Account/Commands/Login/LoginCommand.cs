using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Application.Commons.Models.AccountModels;
using Directory.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Directory.Identity.Application.Features.Account.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtHelper _jwtHelper;

    public LoginCommandHandler(UserManager<User> userManager,
        SignInManager<User> signInManager,
        IJwtHelper jwtHelper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtHelper = jwtHelper;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        var user = await _userManager.FindByNameAsync(request.Username);

        await ValidateSignInResult(result);

        var credentials = await _jwtHelper.GenerateJwtTokenAsync(user);

        await _signInManager.SignInAsync(user, false);

        return new LoginResponse
        {
            Token = credentials
        };
    }

    private async Task ValidateSignInResult(SignInResult result)
    {
        if (!result.Succeeded)
        {
            throw new LoginFailedException();
        }

        await Task.FromResult(true);
    }
}