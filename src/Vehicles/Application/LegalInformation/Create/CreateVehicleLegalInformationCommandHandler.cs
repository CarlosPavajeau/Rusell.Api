using Rusell.Shared.Domain.Bus.Command;
using Rusell.Vehicles.Application.CheckExists;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Application.LegalInformation.Create;

public class CreateVehicleLegalInformationCommandHandler : CommandHandler<CreateVehicleLegalInformationCommand>
{
    private readonly VehicleExistsChecker _checker;
    private readonly VehicleLegalInformationCreator _legalInformationCreator;

    public CreateVehicleLegalInformationCommandHandler(VehicleExistsChecker checker,
        VehicleLegalInformationCreator legalInformationCreator)
    {
        _checker = checker;
        _legalInformationCreator = legalInformationCreator;
    }

    protected override async Task Handle(CreateVehicleLegalInformationCommand request,
        CancellationToken cancellationToken)
    {
        var vehicleExists = await _checker.CheckExists(request.LicensePlate);
        if (!vehicleExists) throw new VehicleNotFound();

        await _legalInformationCreator.CreateLegalInformation(request.LicensePlate, request.Type, request.DueDate,
            request.RenovationDate);
    }
}
