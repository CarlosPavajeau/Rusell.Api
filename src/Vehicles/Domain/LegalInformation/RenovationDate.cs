using ValueOf;

namespace Rusell.Vehicles.Domain.LegalInformation;

public class RenovationDate : ValueOf<DateOnly, RenovationDate>
{
    public static implicit operator DateOnly(RenovationDate renovationDate) => renovationDate.Value;
    public static implicit operator RenovationDate(DateOnly renovationDate) => From(renovationDate);
}
