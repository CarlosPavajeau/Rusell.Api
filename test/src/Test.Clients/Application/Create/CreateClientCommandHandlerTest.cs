using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Rusell.Clients.Application.Create;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Clients.Application.Create;

public class CreateClientCommandHandlerTest : ClientsUnitTestCase
{
    private readonly IRequestHandler<CreateClientCommand, Unit> _handler;

    public CreateClientCommandHandlerTest()
    {
        _handler = new CreateClientCommandHandler(new ClientCreator(Repository.Object, new Mock<IEventBus>().Object));
    }

    [Fact]
    public async Task Create_Should_Create_A_Client()
    {
        var command = new CreateClientCommand(
            Guid.NewGuid().ToString(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random());

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}
