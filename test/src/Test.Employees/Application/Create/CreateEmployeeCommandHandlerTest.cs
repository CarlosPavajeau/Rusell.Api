using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Rusell.Employees.Application.Create;
using Rusell.Employees.Domain;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Employees.Application.Create;

public class CreateEmployeeCommandHandlerTest : EmployeesUnitTestCase
{
    private readonly IRequestHandler<CreateEmployeeCommand, Unit> _handler;

    public CreateEmployeeCommandHandlerTest()
    {
        _handler = new CreateEmployeeCommandHandler(
            new EmployeeCreator(Repository.Object, new Mock<IEventBus>().Object));
    }

    [Fact]
    public async Task Create_Should_Create_An_Employee()
    {
        var command = new CreateEmployeeCommand(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            EmployeeType.Driver,
            Guid.NewGuid());

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}
