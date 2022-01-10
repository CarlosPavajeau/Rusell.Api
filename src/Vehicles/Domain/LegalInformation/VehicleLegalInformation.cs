namespace Rusell.Vehicles.Domain.LegalInformation;

public class VehicleLegalInformation
{
    public VehicleLegalInformation(LegalInformationType type, DueDate dueDate, RenovationDate renovationDate)
    {
        Id = LegalInformationId.From(Guid.NewGuid());
        Type = type;
        DueDate = dueDate;
        RenovationDate = renovationDate;
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
}
