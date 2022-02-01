using ValueOf;

namespace Rusell.TransportSheets.Domain;

public class TransportSheetQuota : ValueOf<uint, TransportSheetQuota>
{
    public static implicit operator uint(TransportSheetQuota transportSheetQuota) => transportSheetQuota.Value;
    public static implicit operator TransportSheetQuota(uint transportSheetQuota) => From(transportSheetQuota);
}
