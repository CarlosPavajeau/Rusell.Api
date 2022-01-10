using ValueOf;

namespace Rusell.Vehicles.Domain;

public class PropertyCard : ValueOf<string, PropertyCard>
{
    public static implicit operator string(PropertyCard propertyCard) => propertyCard.Value;
    public static implicit operator PropertyCard(string propertyCard) => From(propertyCard);
}
