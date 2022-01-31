using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Employees.Domain;

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

    public ICollection<Parcel> Parcels { get; set; }
}
