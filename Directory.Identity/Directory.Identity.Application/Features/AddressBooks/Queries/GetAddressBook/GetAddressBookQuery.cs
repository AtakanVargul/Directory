using AutoMapper;
using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Domain.Entities;
using MediatR;

namespace Directory.Identity.Application.Features.AddressBooks.Queries.GetAddressBook;

public class GetAddressBookQuery : IRequest<AddressBookDetailDto>
{
    public Guid Id { get; set; }
}

public class GetAddressBookQueryHandler : IRequestHandler<GetAddressBookQuery, AddressBookDetailDto>
{
    private readonly IRepository<AddressBook> _repository;
    private readonly IMapper _mapper;

    public GetAddressBookQueryHandler(IRepository<AddressBook> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AddressBookDetailDto> Handle(GetAddressBookQuery command, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(command.Id);

        if (result is null)
        {
            throw new NotFoundException(nameof(AddressBook));
        }

        var contact = _mapper.Map<ContactDto>(result.Contact);
        var location = _mapper.Map<LocationDto>(result.Contact.Location);

        return new AddressBookDetailDto { Name = result.Name, LastName = result.LastName, Firm = result.Firm, Contact = contact, Location = location };
    }
}