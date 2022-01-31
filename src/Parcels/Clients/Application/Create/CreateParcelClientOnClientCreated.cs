using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Clients.Domain;

namespace Rusell.Parcels.Clients.Application.Create;

public class CreateParcelClientOnClientCreated : IDomainEventSubscriber<ClientCreatedDomainEvent>
{
    private readonly ClientCreator _creator;

    public CreateParcelClientOnClientCreated(ClientCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(ClientCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(notification.AggregateId, notification.FullName);
    }
}
