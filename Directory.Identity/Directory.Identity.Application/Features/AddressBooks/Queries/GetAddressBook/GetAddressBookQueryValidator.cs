using FluentValidation;

namespace Directory.Identity.Application.Features.AddressBooks.Queries.GetAddressBook;

public class GetAddressBookQueryValidator : AbstractValidator<GetAddressBookQuery>
{
    public GetAddressBookQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty();
    }
}