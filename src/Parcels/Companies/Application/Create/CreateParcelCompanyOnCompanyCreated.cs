using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Companies.Domain;

namespace Rusell.Parcels.Companies.Application.Create;

public class CreateParcelCompanyOnCompanyCreated : IDomainEventSubscriber<CompanyCreatedDomainEvent>
{
    private readonly CompanyCreator _creator;

    public CreateParcelCompanyOnCompanyCreated(CompanyCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(CompanyCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(Guid.Parse(notification.AggregateId), notification.Name);
    }
}
