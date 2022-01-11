namespace Rusell.Vehicles.Api.Controllers.Requests;

public record CreateVehicleRequest(
    string LicensePlate,
    string InternalNumber,
    string PropertyCard,
    string Type,
    string Mark,
    string Model,
    string ModelNumber,
    string Color,
    int Chairs,
    string EngineNumber,
    string ChassisNumber,
    string OwnerId,
    string DriverId);
