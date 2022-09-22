using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Domain.Entities;
using MediatR;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.UpdateAddressBook;

public class UpdateAddressBookCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Firm { get; set; }
}

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressBookCommand>
{
    private readonly IRepository<AddressBook> _repository;

    public UpdateAddressCommandHandler(IRepository<AddressBook> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateAddressBookCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(AddressBook));
        }

        entity.Firm = command.Firm;
        entity.Name = command.Name;
        entity.LastName = command.LastName;

        await _repository.UpdateAsync(entity);

        return Unit.Value;
    }
}