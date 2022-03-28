using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.Tickets.Domain;
using Rusell.Tickets.Domain;
using Xunit;

namespace Rusell.Test.Tickets.Infrastructure.Persistence;

public class TicketsRepository : TicketContextInfrastructureTestCase
{
    private ITicketsRepository Repository => GetService<ITicketsRepository>();

    [Fact]
    public async Task Save_Should_Save_Ticket()
    {
        var ticket = TicketMother.Random(Guid.NewGuid());

        await Repository.Save(ticket);
    }

    [Fact]
    public async Task SearchAllByTransportSheet_Should_Return_All_Tickets_In_Transport_Sheet()
    {
        var transportSheetId = Guid.NewGuid();
        const int numberOfTickets = 10;

        for (var i = 0; i < numberOfTickets; i++)
        {
            var ticket = TicketMother.Random(transportSheetId);
            await Repository.Save(ticket);
        }

        var tickets = await Repository.SearchAll(t => t.TransportSheetId.Value == transportSheetId);

        tickets.Should().HaveCount(numberOfTickets);
    }

    [Fact]
    public async Task Find_Should_Return_A_Ticket()
    {
        var ticket = TicketMother.Random(Guid.NewGuid());
        await Repository.Save(ticket);

        var foundTicket = await Repository.Find(ticket.Id);

        foundTicket.Should().NotBeNull();
        foundTicket?.Id.Should().Be(ticket.Id);
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var foundTicket = await Repository.Find(Guid.NewGuid());

        foundTicket.Should().BeNull();
    }
}
