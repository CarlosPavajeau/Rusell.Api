using Rusell.Routes.Domain;

namespace Rusell.Routes.Addresses.Domain;

public class Address
{
    public AddressId Id { get; set; }
    public Country Country { get; set; }
    public State State { get; set; }
    public City City { get; set; }

    public IEnumerable<Route> Routes => Routes1.Concat(Routes2).Distinct();

    // For ef core many to many relationship
    public ICollection<Route> Routes1 { get; set; }
    public ICollection<Route> Routes2 { get; set; }

    public override string ToString() => $"{Country}, {State}, {City}";
}
