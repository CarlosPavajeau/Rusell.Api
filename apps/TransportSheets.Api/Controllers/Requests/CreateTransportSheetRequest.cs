namespace Rusell.TransportSheets.Api.Controllers.Requests;

public record CreateTransportSheetRequest(uint Quota, string VehicleLicensePlate, string DispatcherId, Guid RouteId);
