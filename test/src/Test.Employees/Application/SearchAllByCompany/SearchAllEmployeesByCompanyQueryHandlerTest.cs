using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Employees.Application.SearchAllByCompany;
using Rusell.Employees.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Employees.Application.SearchAllByCompany;

public class SearchAllEmployeesByCompanyQueryHandlerTest : EmployeesUnitTestCase
{
    private readonly SearchAllEmployeesByCompanyQueryHandler _handler;
    private readonly Guid _companyId = Guid.NewGuid();

    public SearchAllEmployeesByCompanyQueryHandlerTest()
    {
        _handler = new SearchAllEmployeesByCompanyQueryHandler(new EmployeesByCompanySearcher(Repository.Object));

        Repository.Setup(x => x.SearchAllByCompany(_companyId)).ReturnsAsync(new List<Employee>
        {
            new(
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                EmployeeType.Driver,
                _companyId)
        });
    }

    [Fact]
    public async Task SearchAllEmployeesByCompany_Should_Return_Employees()
    {
        var result = await _handler.Handle(new SearchAllEmployeesByCompanyQuery(_companyId), CancellationToken.None);

        result.Should().NotBeEmpty();
    }
}
