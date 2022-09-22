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
    private readonly IRepository<Location> _locationRepository;
    private readonly IRepository<Contact> _contactRepository;
    private readonly IRepository<User> _userRepository;

    public CreateAddressBookCommandHandler(UserManager<User> userManager,
        IRepository<AddressBook> repository,
        IRepository<User> userRepository,
        IRepository<Contact> contactRepository,
        IRepository<Location> locationRepository)
    {
        _userManager = userManager;
        _repository = repository;
        _userRepository = userRepository;
        _contactRepository= contactRepository;
        _locationRepository= locationRepository;
    }

    public async Task<Unit> Handle(CreateAddressBookCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(command.UserId.ToString());

        if (user is null)
        {
            throw new NotFoundException(nameof(User));
        }

        var Location = new Location
        {
            Country = command.Location.Country,
            City = command.Location.City,
            State = command.Location.State,
            Neighbourhood = command.Location.Neighbourhood,
            Street = command.Location.Street,
            OpenAddress = command.Location.OpenAddress,
            Zip = command.Location.Zip,
            CreatedBy = command.UserId.ToString()
        };
        await _locationRepository.AddAsync(Location);


        var Contact = new Contact
        {
            EmailAdress = command.Contact.EmailAdress,
            PhoneNumber = command.Contact.PhoneNumber,
            CreatedBy = command.UserId.ToString(),
            Location  = Location

        };
        await _contactRepository.AddAsync(Contact);


        var entity = new AddressBook
        {
            UserId = command.UserId,
            Firm = command.Firm,
            LastName = command.LastName,
            Name = command.Name,
            CreatedBy = command.UserId.ToString(),
            Contact = Contact
        };
        await _repository.AddAsync(entity);

        return Unit.Value;
    }
}