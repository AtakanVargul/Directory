using Directory.Identity.Application.Features.AddressBooks.Commands.CreateAddressBook;
using Directory.Identity.Application.Features.AddressBooks.Commands.DeleteAddressBook;
using Directory.Identity.Application.Features.AddressBooks.Commands.UpdateAddressBook;
using Directory.Identity.Application.Features.AddressBooks.Commands.UpdateContact;
using Directory.Identity.Application.Features.AddressBooks.Commands.UpdateLocation;
using Directory.Identity.Application.Features.AddressBooks.Queries;
using Directory.Identity.Application.Features.AddressBooks.Queries.GetAddressBook;
using Directory.Identity.Application.Features.AddressBooks.Queries.GetAllAddressBooks;
using Microsoft.AspNetCore.Mvc;

namespace Directory.Identity.API.Controllers;

public class AddressBooksController : ApiControllerBase
{
    [HttpGet("{addressBookId}")]
    public async Task<ActionResult<AddressBookDetailDto>> GetAsync(Guid addressBookId)
    {
        return await Mediator.Send(new GetAddressBookQuery { Id = addressBookId });
    }

    [HttpGet("{userId}")]
    public async Task<List<AddressBookDto>> GetAllAsync(Guid userId)
    {
        return await Mediator.Send(new GetAllAddressBooksQuery { UserId = userId });
    }

    [HttpPost("")]
    public async Task CreateAsync(CreateAddressBookCommand command)
    {
        await Mediator.Send(command);
    }

    [HttpPut("{addressBookId}")]
    public async Task UpdateAsync(UpdateAddressBookCommand command)
    {
        await Mediator.Send(command);
    }

    [HttpPut("{addressBookId}/location")]
    public async Task UpdateLocationAsync(UpdateLocationCommand command)
    {
        await Mediator.Send(command);
    }

    [HttpPut("{addressBookId}/contact")]
    public async Task UpdateContactAsync(UpdateContactCommand command)
    {
        await Mediator.Send(command);
    }

    [HttpDelete("{addressBookId}")]
    public async Task DeleteAsync(DeleteAddressBookCommand command)
    {
        await Mediator.Send(command);
    }
}