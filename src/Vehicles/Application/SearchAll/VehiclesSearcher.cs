using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Application.SearchAll;

public class VehiclesSearcher
{
    private readonly IVehiclesRepository _repository;

    public VehiclesSearcher(IVehiclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Vehicle>> SearchAll(CompanyId companyId)
    {
        return await _repository.SearchAll(x => x.CompanyId == companyId);
    }
}
