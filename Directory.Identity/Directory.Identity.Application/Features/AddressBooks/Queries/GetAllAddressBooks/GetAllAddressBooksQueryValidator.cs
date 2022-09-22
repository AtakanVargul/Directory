using FluentValidation;

namespace Directory.Identity.Application.Features.AddressBooks.Queries.GetAllAddressBooks;

public class GetAllAddressBooksQueryValidator : AbstractValidator<GetAllAddressBooksQuery>
{
    public GetAllAddressBooksQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().NotEmpty();
    }
}