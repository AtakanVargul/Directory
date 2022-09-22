using Directory.Identity.Application.Commons.Mappings;
using Directory.Identity.Domain.Entities;

namespace Directory.Identity.Application.Features.AddressBooks.Queries;

public class ContactDto : IMapFrom<Contact>
{
    public string PhoneNumber { get; set; }
    public string EmailAdress { get; set; }
}