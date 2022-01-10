using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Employees.Application.SearchAllByType;
using Rusell.Employees.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Employees.Application.SearchAllByType;

public class SearchAllCompanyEmployeesByTypeQueryHandlerTest : EmployeesUnitTestCase
{
    private readonly SearchAllCompanyEmployeesByTypeQueryHandler _handler;
    private readonly Guid _companyId = Guid.NewGuid();

    public SearchAllCompanyEmployeesByTypeQueryHandlerTest()
    {
        _handler = new SearchAllCompanyEmployeesByTypeQueryHandler(
            new CompanyEmployeesByTypeSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAllByType(_companyId, EmployeeType.Driver)).ReturnsAsync(new List<Employee>
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
    public async Task SearchAllCompanyEmployeesByType_Should_Return_All_Employees()
    {
        var result = await _handler.Handle(new SearchAllCompanyEmployeesByTypeQuery(_companyId, EmployeeType.Driver),
            CancellationToken.None);

        result.Should().NotBeEmpty();
    }
}
