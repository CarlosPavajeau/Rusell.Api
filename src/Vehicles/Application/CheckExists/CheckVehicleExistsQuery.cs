using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Vehicles.Application.CheckExists;

public record CheckVehicleExistsQuery(string LicensePlate) : Query<bool>;
