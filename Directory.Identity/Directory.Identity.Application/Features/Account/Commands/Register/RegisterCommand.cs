using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Exceptions.PasswordValidations;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Application.Commons.Models.AccountModels;
using Directory.Identity.Application.Commons.Models.Persistence;
using Directory.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Directory.Identity.Application.Features.Account.Commands.Register;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtHelper _jwtHelper;

    public RegisterCommandHandler(UserManager<User> userManager,
        IJwtHelper jwtHelper)
    {
        _userManager = userManager;
        _jwtHelper = jwtHelper;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var emailUser = await _userManager.FindByNameAsync(command.PhoneNumber);
        if (emailUser is not null)
        {
            throw new AlreadyInUseException(nameof(User));
        }

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            UserName = command.PhoneNumber,
            PhoneNumber = command.PhoneNumber,
            PhoneNumberConfirmed = true,
            Email = command.Email,
            EmailConfirmed = true,
            CreateDate = DateTime.UtcNow,
            RecordStatus = RecordStatus.Active
        };

        var result = await _userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            var errorCode = result.Errors.FirstOrDefault()?.Code;

            switch (errorCode)
            {
                case "PasswordContentError":
                    throw new PasswordContentException();
                case "PasswordLengthError":
                    throw new PasswordLengthException();
                case "PasswordRepetitiveCharacterError":
                    throw new PasswordRepetitiveCharacterException();
                case "PasswordSuccessiveCharacterError":
                    throw new PasswordSuccessiveCharacterException();
                default:
                    throw new InvalidRegisterException();
            }
        }

        var credentials = await _jwtHelper.GenerateJwtTokenAsync(user);

        return new RegisterResponse
        {
            Token = credentials,
            UserId = user.Id
        };
    }
}