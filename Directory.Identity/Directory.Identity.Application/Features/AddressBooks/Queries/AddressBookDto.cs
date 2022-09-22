using Directory.Identity.Application.Commons.Mappings;
using Directory.Identity.Domain.Entities;

namespace Directory.Identity.Application.Features.AddressBooks.Queries;

public class AddressBookDto : IMapFrom<AddressBook>
{
    public string Name { get; set; }
    public string LastName { get; set; }
}