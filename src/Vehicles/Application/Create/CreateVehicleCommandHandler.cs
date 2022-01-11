using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Vehicles.Application.Create;

public class CreateVehicleCommandHandler : CommandHandler<CreateVehicleCommand>
{
    private readonly VehicleCreator _creator;

    public CreateVehicleCommandHandler(VehicleCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        await _creator.Create(request);
    }
}
