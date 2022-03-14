using Rusell.Employees.Domain;
using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Employees.Application.Create;

public record CreateEmployeeCommand(string Id, string FirstName, string MiddleName, string FirstSurname,
    string SecondSurname, string? Email, string PhoneNumber, EmployeeType Type, string UserId, Guid CompanyId) : Command
{
    public Guid CompanyId { get; set; }
}
