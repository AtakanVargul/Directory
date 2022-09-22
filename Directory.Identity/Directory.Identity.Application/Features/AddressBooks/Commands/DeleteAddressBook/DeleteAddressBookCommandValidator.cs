using FluentValidation;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.DeleteAddressBook;

public class DeleteAddressBookCommandValidator : AbstractValidator<DeleteAddressBookCommand>
{
    public DeleteAddressBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty();
    }
}