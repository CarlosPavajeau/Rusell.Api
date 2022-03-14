using System;
using Rusell.Employees.Domain;
using Rusell.Test.Shared.Domain;

namespace Rusell.Test.Employees.Domain;

public static class EmployeeMother
{
    public static Employee Random(Guid companyId) => Employee.Create(
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        EmployeeType.Dispatcher,
        companyId,
        Guid.NewGuid().ToString());
}
