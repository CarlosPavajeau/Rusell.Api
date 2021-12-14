namespace Rusell.Addresses.Api.Controllers.Requests;

public class CreateAddressRequest
{
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string? Neighborhood { get; set; }
    public string StreetName { get; set; }
    public string Intersection { get; set; }
    public string StreetNumber { get; set; }
    public string? Comments { get; set; }
}
