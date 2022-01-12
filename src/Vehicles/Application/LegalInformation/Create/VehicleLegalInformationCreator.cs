using Rusell.Vehicles.Domain;
using Rusell.Vehicles.Domain.LegalInformation;

namespace Rusell.Vehicles.Application.LegalInformation.Create;

public class VehicleLegalInformationCreator
{
    private readonly ILegalInformationRepository _repository;

    public VehicleLegalInformationCreator(ILegalInformationRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateLegalInformation(LicensePlate licensePlate, LegalInformationType legalInformationType,
        DueDate dueDate, RenovationDate renovationDate)
    {
        var legalInformation =
            VehicleLegalInformation.Create(legalInformationType, dueDate, renovationDate, licensePlate);
        await _repository.Save(legalInformation);
    }
}
