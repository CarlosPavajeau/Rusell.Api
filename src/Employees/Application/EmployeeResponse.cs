using Rusell.Employees.Domain;

namespace Rusell.Employees.Application;

public record EmployeeResponse(
    string Id,
    string FullName,
    string? Email,
    string PhoneNumber,
    EmployeeType Type,
    Guid CompanyId
);
