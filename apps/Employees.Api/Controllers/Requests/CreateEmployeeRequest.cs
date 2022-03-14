using Rusell.Employees.Domain;

namespace Rusell.Employees.Api.Controllers.Requests;

public record CreateEmployeeRequest(string Id, string FirstName, string MiddleName, string FirstSurname,
    string SecondSurname, string? Email, string PhoneNumber, EmployeeType Type, string UserId);
