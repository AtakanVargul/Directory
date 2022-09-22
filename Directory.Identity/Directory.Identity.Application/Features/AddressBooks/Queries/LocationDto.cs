using Directory.Identity.Application.Commons.Mappings;
using Directory.Identity.Domain.Entities;

namespace Directory.Identity.Application.Features.AddressBooks.Queries;

public class LocationDto : IMapFrom<Location>
{
    public string Country { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Neighbourhood { get; set; }
    public string Street { get; set; }
    public string OpenAddress { get; set; }
    public string Zip { get; set; }
}