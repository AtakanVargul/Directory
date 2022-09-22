using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Domain.Entities;
using MediatR;

namespace Directory.Identity.Application.Features.AddressBooks.Commands.UpdateLocation;

public class UpdateLocationCommand : IRequest
{
    public Guid Id { get; set; }
}

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public UpdateLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(command.Id);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Location));
        }

        return Unit.Value;
    }
}