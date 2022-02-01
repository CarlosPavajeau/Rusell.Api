using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Clients.Domain;

namespace Rusell.Tickets.Clients.Application.Create;

public class CreateTicketClientOnClientCreated : IDomainEventSubscriber<ClientCreatedDomainEvent>
{
    private readonly ClientCreator _creator;

    public CreateTicketClientOnClientCreated(ClientCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(ClientCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(notification.AggregateId, notification.FullName);
    }
}
