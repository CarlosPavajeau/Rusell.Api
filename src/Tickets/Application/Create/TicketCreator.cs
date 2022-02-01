using Mapster;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Application.Create;

public class TicketCreator
{
    private readonly ITicketsRepository _repository;

    public TicketCreator(ITicketsRepository repository)
    {
        _repository = repository;
    }

    public async Task<TicketId> Create(CreateTicketCommand command)
    {
        var ticket = command.Adapt<Ticket>();
        await _repository.Save(ticket);

        return ticket.Id;
    }
}
