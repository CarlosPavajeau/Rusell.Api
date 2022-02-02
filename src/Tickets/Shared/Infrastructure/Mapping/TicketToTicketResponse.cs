using Mapster;
using Rusell.Tickets.Application;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Shared.Infrastructure.Mapping;

public class TicketToTicketResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Ticket, TicketResponse>()
            .MapWith(v =>
                new TicketResponse(
                    v.Id,
                    v.Date,
                    v.State,
                    v.SeatPrice,
                    v.Seats,
                    v.Total,
                    v.Client.FullName));
    }
}
