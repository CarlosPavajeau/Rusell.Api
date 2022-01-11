namespace Rusell.Vehicles.Application;

public record VehicleResponse(
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
    string DriverName);
