using Moq;
using Rusell.Test.Shared.Infrastructure;
using Rusell.Tickets.Domain;

namespace Rusell.Test.Tickets;

public class TicketsUnitTestCase : UnitTestCase
{
    protected readonly Mock<ITicketsRepository> Repository;

    protected TicketsUnitTestCase()
    {
        Repository = new Mock<ITicketsRepository>();
    }
}
