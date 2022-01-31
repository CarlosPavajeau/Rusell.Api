namespace Rusell.Parcels.Api.Controllers.Requests;

public record CreateParcelRequest(
    string Description,
    decimal Cost,
    string VehicleLicensePlate,
    string DispatcherId,
    string SenderId,
    string ReceiverId);
