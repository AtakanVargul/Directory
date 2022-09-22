using FluentValidation;

namespace Directory.Identity.Application.Features.Account.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotNull().MaximumLength(15)
            .WithMessage("Invalid PhoneNumber.");

        RuleFor(x => x.Password)
            .NotNull().Length(6)
            .WithMessage("Invalid password.");
    }
}