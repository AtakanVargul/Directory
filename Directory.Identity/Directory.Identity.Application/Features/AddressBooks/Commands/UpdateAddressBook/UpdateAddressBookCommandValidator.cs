using FluentValidation;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.UpdateAddressBook;

public class UpdateAddressBookCommandValidator : AbstractValidator<UpdateAddressBookCommand>
{
    public UpdateAddressBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty();

        RuleFor(x => x.Name)
            .NotNull().NotEmpty();

        RuleFor(x => x.LastName)
            .NotNull().NotEmpty();

        RuleFor(x => x.Firm)
            .NotNull().NotEmpty();
    }
}