using FluentValidation;

namespace Directory.Identity.Application.Features.Account.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .NotNull().NotEmpty();

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .NotNull().NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(15)
            .NotNull().NotEmpty();

        RuleFor(x => x.Email)
            .MaximumLength(50).EmailAddress()
            .NotNull().NotEmpty();

        RuleFor(x => x.Password)
            .Length(6)
            .NotNull().NotEmpty();
    }
}