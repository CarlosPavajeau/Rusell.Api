using MediatR;
using Moq;

namespace Rusell.Test.Shared.Infrastructure;

public abstract class UnitTestCase
{
    protected readonly Mock<IMediator> Mediator;

    protected UnitTestCase()
    {
        Mediator = new Mock<IMediator>();
    }
}