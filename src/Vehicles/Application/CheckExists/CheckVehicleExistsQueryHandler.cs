using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Vehicles.Application.CheckExists;

public class CheckVehicleExistsQueryHandler : IQueryHandler<CheckVehicleExistsQuery, bool>
{
    private readonly VehicleExistsChecker _checker;

    public CheckVehicleExistsQueryHandler(VehicleExistsChecker checker)
    {
        _checker = checker;
    }

    public Task<bool> Handle(CheckVehicleExistsQuery request, CancellationToken cancellationToken) =>
        _checker.CheckExists(request.LicensePlate);
}
