using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Tickets.Application.Create;

public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, Guid>
{
    private readonly TicketCreator _creator;

    public CreateTicketCommandHandler(TicketCreator creator)
    {
        _creator = creator;
    }

    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
