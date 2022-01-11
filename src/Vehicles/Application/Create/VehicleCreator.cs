using Mapster;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Application.Create;

public class VehicleCreator
{
    private readonly IVehiclesRepository _repository;

    public VehicleCreator(IVehiclesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateVehicleCommand command)
    {
        var vehicle = command.Adapt<Vehicle>();
        await _repository.Save(vehicle);
    }
}
