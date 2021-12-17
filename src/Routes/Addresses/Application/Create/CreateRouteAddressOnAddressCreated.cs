using Rusell.Shared.Domain.Address.Domain;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Routes.Addresses.Application.Create;

public class CreateRouteAddressOnAddressCreated : IDomainEventSubscriber<AddressCreatedDomainEvent>
{
    private readonly AddressCreator _creator;

    public CreateRouteAddressOnAddressCreated(AddressCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(AddressCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(Guid.Parse(notification.AggregateId), notification.Country, notification.State,
            notification.City);
    }
}
