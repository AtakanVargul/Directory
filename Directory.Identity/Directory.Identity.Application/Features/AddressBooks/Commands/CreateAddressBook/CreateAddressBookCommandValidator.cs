using FluentValidation;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.CreateAddressBook;

public class CreateAddressBookCommandValidator : AbstractValidator<CreateAddressBookCommand>
{
    public CreateAddressBookCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().NotEmpty();
    }
}