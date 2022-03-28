using System;
using Rusell.Test.Shared.Domain;
using Rusell.Tickets.Clients.Domain;
using Rusell.Tickets.Domain;

namespace Rusell.Test.Tickets.Domain;

public static class TicketMother
{
    public static Ticket Random(Guid transportSheetId)
    {
        var client = new Client(ClientId.From(Guid.NewGuid().ToString()), ClientName.From(WordMother.Random()));

        return new TicketBuilder()
            .WithId(TicketId.From(Guid.NewGuid()))
            .WithDate(TicketDate.From(DateTime.UtcNow))
            .WithState(TicketState.Pending)
            .WithSeatPrice(TicketSeatPrice.From(MotherCreator.Random().Decimal(1, 1000)))
            .WithSeats(TicketSeats.From(MotherCreator.Random().UInt(1, 10)))
            .WithClient(client)
            .WithClientId(client.Id)
            .WithTransportSheetId(TransportSheetId.From(transportSheetId))
            .Build();
    }
}
