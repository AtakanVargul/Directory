using FluentValidation;

namespace Directory.Identity.Application.Features.Account.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {

        RuleFor(x => x.FirstName)
            .MaximumLength(50).NotNull().NotEmpty();

        RuleFor(x => x.LastName)
            .MaximumLength(50).NotNull().NotEmpty();

        RuleFor(x => x.UserName)
            .MaximumLength(50).NotNull().NotEmpty();

        RuleFor(x => x.Password)
            .Length(6)
            .NotNull().NotEmpty();
    }
}