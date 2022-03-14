using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Employees.Domain;
using Rusell.Test.Employees.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Employees.Infrastructure.Persistence;

public class EmployeesRepositoryTest : EmployeesContextInfrastructureTestCase
{
    private IEmployeesRepository Repository => GetService<IEmployeesRepository>();

    [Fact]
    public async Task Save_Should_Save_Employee()
    {
        var employee = EmployeeMother.Random(Guid.NewGuid());

        await Repository.Save(employee);
    }

    [Fact]
    public async Task SearchAll_Should_Return_All_Employees()
    {
        var employee = EmployeeMother.Random(Guid.NewGuid());

        await Repository.Save(employee);

        var employees = await Repository.SearchAll();

        employees.Should().NotBeEmpty();
    }

    [Fact]
    public async Task SearchAllByCompany_Should_Return_All_Employees()
    {
        var employee = EmployeeMother.Random(Guid.NewGuid());

        await Repository.Save(employee);

        var employees = await Repository.SearchAllByCompany(employee.CompanyId);

        employees.Should().NotBeEmpty();
    }

    [Fact]
    public async Task SearchAllByType_Should_Return_All_Employees()
    {
        var employee = EmployeeMother.Random(Guid.NewGuid());

        await Repository.Save(employee);

        var employees = await Repository.SearchAllByType(employee.CompanyId, employee.Type);

        employees.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Find_Should_Return_An_Employee()
    {
        var employee = EmployeeMother.Random(Guid.NewGuid());

        await Repository.Save(employee);

        var foundEmployee = await Repository.Find(employee.Id);

        foundEmployee.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var foundEmployee = await Repository.Find(WordMother.Random());

        foundEmployee.Should().BeNull();
    }
}
