using Rusell.Shared.Domain.Aggregate;
using Rusell.Shared.Domain.Employees.Domain;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Employees.Domain;

public class Employee : AggregateRoot
{
    public Employee(EmployeeId id, FirstName firstName, MiddleName middleName, FirstSurname firstSurname,
        SecondSurname secondSurname, Email? email, PhoneNumber phoneNumber, EmployeeType type, CompanyId companyId,
        UserId userId)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        FirstSurname = firstSurname;
        SecondSurname = secondSurname;
        Email = email;
        PhoneNumber = phoneNumber;
        Type = type;
        CompanyId = companyId;
        UserId = userId;
    }

    private Employee()
    {
        // Ef Core
    }

    public EmployeeId Id { get; set; }

    public FirstName FirstName { get; set; }
    public MiddleName MiddleName { get; set; }
    public FirstSurname FirstSurname { get; set; }
    public SecondSurname SecondSurname { get; set; }

    public Email? Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }

    public EmployeeType Type { get; set; }

    public CompanyId CompanyId { get; set; }

    public UserId UserId { get; set; }

    public static Employee Create(EmployeeId id, FirstName firstName, MiddleName middleName, FirstSurname firstSurname,
        SecondSurname secondSurname, Email? email, PhoneNumber phoneNumber, EmployeeType type, CompanyId companyId,
        UserId userId)
    {
        var employee = new Employee(id, firstName, middleName, firstSurname, secondSurname, email, phoneNumber, type,
            companyId, userId);

        employee.Record(new EmployeeCreatedDomainEvent(id, $"{firstName} {middleName} {firstSurname} {secondSurname}"));

        return employee;
    }
}
