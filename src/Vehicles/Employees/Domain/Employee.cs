using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Employees.Domain;

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

    public ICollection<Vehicle> VehiclesThatDrives { get; set; }
    public ICollection<Vehicle> VehiclesThatOwn { get; set; }
}
