using ValueOf;

namespace Rusell.Vehicles.Domain.LegalInformation;

public class DueDate : ValueOf<DateOnly, DueDate>
{
    public static implicit operator DateOnly(DueDate dueDate) => dueDate.Value;
    public static implicit operator DueDate(DateOnly dueDate) => From(dueDate);
    public static implicit operator DueDate(DateTime dueDate) => From(DateOnly.FromDateTime(dueDate));
}
