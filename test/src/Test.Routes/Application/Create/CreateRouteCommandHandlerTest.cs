using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rusell.Routes.Application.Create;
using Xunit;

namespace Rusell.Test.Routes.Application.Create;

public class CreateRouteCommandHandlerTest : RoutesUnitTestCase
{
    private readonly IRequestHandler<CreateRouteCommand, Unit> _handler;

    public CreateRouteCommandHandlerTest()
    {
        _handler = new CreateRouteCommandHandler(new RouteCreator(Repository.Object));
    }

    [Fact]
    public async Task Create_Should_Create_A_Route()
    {
        var command = new CreateRouteCommand(Guid.NewGuid(), Guid.NewGuid(), 15000, false, false, Guid.NewGuid());

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}
