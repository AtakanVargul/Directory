using FluentValidation;

namespace Directory.Identity.Application.Features.Account.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotNull().MinimumLength(10).MaximumLength(20)
            .WithMessage("Invalid username.");

        RuleFor(x => x.Password)
            .NotNull().MinimumLength(6).MaximumLength(6)
            .WithMessage("Invalid password.");
    }
}