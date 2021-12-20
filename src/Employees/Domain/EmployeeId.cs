using ValueOf;

namespace Rusell.Employees.Domain;

public class EmployeeId : ValueOf<string, EmployeeId>
{
    public static implicit operator string(EmployeeId employeeId) => employeeId.Value;
    public static implicit operator EmployeeId(string employeeId) => From(employeeId);
}
