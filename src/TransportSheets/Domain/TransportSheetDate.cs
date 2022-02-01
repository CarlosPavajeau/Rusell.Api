using ValueOf;

namespace Rusell.TransportSheets.Domain;

public class TransportSheetDate : ValueOf<DateTime, TransportSheetDate>
{
    public static implicit operator DateTime(TransportSheetDate transportSheetDate) => transportSheetDate.Value;
    public static implicit operator TransportSheetDate(DateTime transportSheetDate) => From(transportSheetDate);
}
