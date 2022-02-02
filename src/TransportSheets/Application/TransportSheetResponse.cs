namespace Rusell.TransportSheets.Application;

public record TransportSheetResponse(
    DateTime Date,
    DateTime? DepartureTime,
    uint Quota,
    string VehicleLicensePlate,
    string DispatcherName);
