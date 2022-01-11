using Rusell.Shared.Domain.Aggregate;
using Rusell.Vehicles.Domain.LegalInformation;
using Rusell.Vehicles.Employees.Domain;

namespace Rusell.Vehicles.Domain;

public class Vehicle : AggregateRoot
{
    public Vehicle(LicensePlate licensePlate, InternalNumber internalNumber, PropertyCard propertyCard,
        VehicleType type, VehicleMark mark, VehicleModel model, VehicleModelNumber modelNumber, VehicleColor color,
        VehicleChairs chairs, EngineNumber engineNumber, ChassisNumber chassisNumber, EmployeeId ownerId,
        Employee owner, EmployeeId driverId,
        Employee driver, CompanyId companyId)
    {
        LicensePlate = licensePlate;
        InternalNumber = internalNumber;
        PropertyCard = propertyCard;
        Type = type;
        Mark = mark;
        Model = model;
        ModelNumber = modelNumber;
        Color = color;
        Chairs = chairs;
        EngineNumber = engineNumber;
        ChassisNumber = chassisNumber;
        OwnerId = ownerId;
        Owner = owner;
        DriverId = driverId;
        Driver = driver;
        CompanyId = companyId;
    }

    internal Vehicle()
    {
    }

    public LicensePlate LicensePlate { get; set; }
    public InternalNumber InternalNumber { get; set; }
    public PropertyCard PropertyCard { get; set; }
    public VehicleType Type { get; set; }
    public VehicleMark Mark { get; set; }
    public VehicleModel Model { get; set; }
    public VehicleModelNumber ModelNumber { get; set; }
    public VehicleColor Color { get; set; }
    public VehicleChairs Chairs { get; set; }
    public EngineNumber EngineNumber { get; set; }
    public ChassisNumber ChassisNumber { get; set; }

    public ICollection<VehicleLegalInformation> LegalInformation { get; set; }

    public EmployeeId OwnerId { get; set; }
    public Employee Owner { get; set; }

    public EmployeeId DriverId { get; set; }
    public Employee Driver { get; set; }

    public CompanyId CompanyId { get; set; }
}
