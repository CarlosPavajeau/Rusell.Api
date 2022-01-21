using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Employees.Domain;

public class Employee
{
    public Employee(EmployeeId id, EmployeeName fullName)
    {
        Id = id;
        FullName = fullName;
    }

    private Employee()
    {
        // required by EF
    }

    public EmployeeId Id { get; set; }
    public EmployeeName FullName { get; set; }

    public ICollection<BankDraft> BankDrafts { get; set; }
}
