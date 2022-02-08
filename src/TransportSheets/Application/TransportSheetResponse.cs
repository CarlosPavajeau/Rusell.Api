namespace Rusell.TransportSheets.Application;

public record TransportSheetResponse(
    DateTime Date,
    DateTime? DepartureTime,
    uint Quota,
    string VehicleLicensePlate,
    Guid RouteId,
    string DispatcherName);
