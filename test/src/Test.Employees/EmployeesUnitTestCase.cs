using Mapster;
using Moq;
using Rusell.Employees.Domain;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Employees;

public class EmployeesUnitTestCase : UnitTestCase
{
    protected readonly Mock<IEmployeesRepository> Repository;

    public EmployeesUnitTestCase()
    {
        Repository = new Mock<IEmployeesRepository>();
        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Employees));
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Employee>()), Times.AtLeastOnce());
    }
}
