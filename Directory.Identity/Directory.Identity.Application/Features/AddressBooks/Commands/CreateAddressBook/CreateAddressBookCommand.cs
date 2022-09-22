using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Application.Features.AddressBooks.Queries;
using Directory.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.CreateAddressBook;

public class CreateAddressBookCommand : IRequest
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Firm { get; set; }
    public ContactDto Contact { get; set; }
    public LocationDto Location { get; set; }
}

public class CreateAddressBookCommandHandler : IRequestHandler<CreateAddressBookCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly IRepository<AddressBook> _repository;
    private readonly IRepository<User> _userRepository;

    public CreateAddressBookCommandHandler(UserManager<User> userManager,
        IRepository<AddressBook> repository,
        IRepository<User> userRepository)
    {
        _userManager = userManager;
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(CreateAddressBookCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(command.UserId.ToString());

        if (user is null)
        {
            throw new NotFoundException(nameof(User));
        }

        var entity = new AddressBook
        {
            UserId = command.UserId,
            Firm = command.Firm,
            LastName = command.LastName,
            Name = command.Name,
            Contact = new Contact
            {
                EmailAdress = command.Contact.EmailAdress,
                PhoneNumber = command.Contact.PhoneNumber,
                Location = new Location
                {
                    Country = command.Location.Country,
                    City = command.Location.City,
                    State = command.Location.State,
                    Neighbourhood = command.Location.Neighbourhood,
                    Street = command.Location.Street,
                    OpenAddress = command.Location.OpenAddress,
                    Zip = command.Location.Zip
                }
            }
        };

        await _repository.AddAsync(entity);

        return Unit.Value;
    }
}