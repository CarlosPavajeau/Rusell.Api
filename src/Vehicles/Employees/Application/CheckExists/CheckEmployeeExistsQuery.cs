using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Vehicles.Employees.Application.CheckExists;

public record CheckEmployeeExistsQuery(string Id) : Query<bool>;
