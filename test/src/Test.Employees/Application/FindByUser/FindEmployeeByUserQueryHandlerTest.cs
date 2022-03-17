using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Employees.Application.FindByUser;
using Rusell.Test.Employees.Domain;
using Xunit;

namespace Rusell.Test.Employees.Application.FindByUser;

public class FindEmployeeByUserQueryHandlerTest : EmployeesUnitTestCase
{
    private readonly FindEmployeeByUserQueryHandler _handler;
    private readonly string _userId = "userId";

    public FindEmployeeByUserQueryHandlerTest()
    {
        _handler = new FindEmployeeByUserQueryHandler(new EmployeeByUserFinder(Repository.Object));

        Repository.Setup(x => x.FindByUser(_userId))
            .ReturnsAsync(EmployeeMother.Random(Guid.NewGuid()));
    }

    [Fact]
    public async Task Should_return_employee_by_user()
    {
        var result = await _handler.Handle(new FindEmployeeByUserQuery(_userId), CancellationToken.None);

        result.Should().NotBeNull();
    }
}
