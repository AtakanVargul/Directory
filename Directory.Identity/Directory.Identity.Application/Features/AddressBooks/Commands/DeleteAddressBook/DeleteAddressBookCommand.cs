using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Domain.Entities;
using MediatR;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.DeleteAddressBook;

public class DeleteAddressBookCommand : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressBookCommand>
{
    private readonly IRepository<AddressBook> _repository;

    public DeleteAddressCommandHandler(IRepository<AddressBook> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteAddressBookCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(AddressBook));
        }

        await _repository.DeleteAsync(entity);

        return Unit.Value;
    }
}