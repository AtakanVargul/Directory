using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Domain.Entities;
using MediatR;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.UpdateContact;

public class UpdateContactCommand : IRequest
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAdress { get; set; }
}

public class UpdateAddressCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IRepository<Contact> _repository;

    public UpdateAddressCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateContactCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Contact));
        }

        return Unit.Value;
    }
}