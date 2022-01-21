using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Clients.Domain;

namespace Rusell.BankDrafts.Clients.Application.Create;

public class CreateBankDraftClientOnClientCreated : IDomainEventSubscriber<ClientCreatedDomainEvent>
{
    private readonly ClientCreator _creator;

    public CreateBankDraftClientOnClientCreated(ClientCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(ClientCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(notification.AggregateId, notification.FullName);
    }
}
