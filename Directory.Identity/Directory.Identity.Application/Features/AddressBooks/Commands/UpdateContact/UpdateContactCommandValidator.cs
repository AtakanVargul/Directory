using FluentValidation;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.UpdateContact;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty();
    }
}