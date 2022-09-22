namespace Directory.Identity.Application.Features.AddressBooks.Queries;

public class AddressBookDetailDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Firm { get; set; }
    public ContactDto Contact { get; set; }
    public LocationDto Location { get; set; }
}