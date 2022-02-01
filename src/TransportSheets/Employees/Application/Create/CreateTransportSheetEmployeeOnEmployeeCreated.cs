using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Employees.Domain;

namespace Rusell.TransportSheets.Employees.Application.Create;

public class CreateTransportSheetEmployeeOnEmployeeCreated : IDomainEventSubscriber<EmployeeCreatedDomainEvent>
{
    private readonly EmployeeCreator _creator;

    public CreateTransportSheetEmployeeOnEmployeeCreated(EmployeeCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(EmployeeCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(notification.AggregateId, notification.FullName);
    }
}
