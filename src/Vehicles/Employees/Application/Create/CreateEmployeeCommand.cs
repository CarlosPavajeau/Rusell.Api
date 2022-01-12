using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Vehicles.Employees.Application.Create;

public record CreateEmployeeCommand(string Id, string FullName) : Command;
