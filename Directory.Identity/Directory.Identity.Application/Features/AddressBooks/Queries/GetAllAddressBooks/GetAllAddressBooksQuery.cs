using AutoMapper;
using Directory.Identity.Application.Commons.Exceptions;
using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Directory.Identity.Application.Features.AddressBooks.Queries.GetAllAddressBooks;

public class GetAllAddressBooksQuery : IRequest<List<AddressBookDto>>
{
    public Guid UserId { get; set; }
}

public class GetAllAddressBooksQueryHandler : IRequestHandler<GetAllAddressBooksQuery, List<AddressBookDto>>
{
    private readonly UserManager<User> _userManager;
    private readonly IRepository<AddressBook> _repository;
    private readonly IMapper _mapper;

    public GetAllAddressBooksQueryHandler(UserManager<User> userManager,
        IRepository<AddressBook> repository,
        IMapper mapper)
    {
        _userManager = userManager;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<AddressBookDto>> Handle(GetAllAddressBooksQuery command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(command.UserId.ToString());

        if (user is null)
        {
            throw new NotFoundException(nameof(User));
        }

        var result = await _repository.GetAll().Where(q => q.UserId == command.UserId).ToListAsync(cancellationToken);

        if (result.Count == 0)
        {
            throw new NotFoundException(nameof(AddressBook));
        }

        return _mapper.Map<List<AddressBookDto>>(result);
    }
}