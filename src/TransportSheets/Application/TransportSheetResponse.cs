namespace Rusell.TransportSheets.Application;

public record TransportSheetResponse(
    string Id,
    DateTime Date,
    DateTime? DepartureTime,
    uint Quota,
    string VehicleLicensePlate,
    string RouteId,
    string DispatcherName);
