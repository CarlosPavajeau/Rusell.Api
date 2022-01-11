using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Vehicles.Application.SearchAll;

public record SearchAllVehiclesQuery(Guid CompanyId) : Query<IEnumerable<VehicleResponse>>;
