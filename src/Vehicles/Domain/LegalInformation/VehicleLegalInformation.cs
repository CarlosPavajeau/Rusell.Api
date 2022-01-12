namespace Rusell.Vehicles.Domain.LegalInformation;

public class VehicleLegalInformation
{
    public VehicleLegalInformation(LegalInformationType type, DueDate dueDate, RenovationDate renovationDate,
        LicensePlate vehicleLicensePlate)
    {
        Id = LegalInformationId.From(Guid.NewGuid());
        Type = type;
        DueDate = dueDate;
        RenovationDate = renovationDate;
        VehicleLicensePlate = vehicleLicensePlate;
    }

    private VehicleLegalInformation()
    {
        // required by EF
    }

    public LegalInformationId Id { get; set; }
    public LegalInformationType Type { get; set; }
    public DueDate DueDate { get; set; }
    public RenovationDate RenovationDate { get; set; }

    public LicensePlate VehicleLicensePlate { get; set; }
    public Vehicle Vehicle { get; set; }


    public static VehicleLegalInformation Create(LegalInformationType type, DueDate dueDate,
        RenovationDate renovationDate, LicensePlate vehicleLicensePlate) =>
        new VehicleLegalInformation(type, dueDate, renovationDate, vehicleLicensePlate);
}
