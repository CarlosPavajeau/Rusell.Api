using Mapster;
using Rusell.Tickets.Application.Create;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Shared.Infrastructure.Mapping;

public class CreateTicketCommandToTicket : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTicketCommand, Ticket>()
            .MapWith(v => new TicketBuilder()
                .WithId(Guid.NewGuid())
                .WithDate(DateTime.UtcNow)
                .WithState(TicketState.Pending)
                .WithSeatPrice(v.SeatPrice)
                .WithSeats(v.Seats)
                .WithTotal(v.SeatPrice * v.Seats)
                .WithClientId(v.ClientId)
                .WithTransportSheetId(v.TransportSheetId)
                .Build());
    }
}
