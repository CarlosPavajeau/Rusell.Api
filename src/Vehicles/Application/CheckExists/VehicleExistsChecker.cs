using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Application.CheckExists;

public class VehicleExistsChecker
{
    private readonly IVehiclesRepository _repository;

    public VehicleExistsChecker(IVehiclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CheckExists(LicensePlate licensePlate)
    {
        return await _repository.Any(x => x.LicensePlate == licensePlate);
    }
}
