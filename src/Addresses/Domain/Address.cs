using Rusell.Shared.Domain.Aggregate;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Addresses.Domain;

public class Address : AggregateRoot
{
    public Address()
    {
        Id = AddressId.From(Guid.NewGuid());
    }

    public AddressId Id { get; set; }
    public Country Country { get; set; }
    public State State { get; set; }
    public City City { get; set; }

    public Neighborhood? Neighborhood { get; set; }
    public StreetName StreetName { get; set; }
    public Intersection Intersection { get; set; }
    public StreetNumber StreetNumber { get; set; }
    public Comments? Comments { get; set; }

    public UserId UserId { get; set; }
}