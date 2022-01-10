using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Employees.Domain;

namespace Rusell.Vehicles.Employees.Application.Create;

public class CreateVehicleEmployeeOnEmployeeCreated : IDomainEventSubscriber<EmployeeCreatedDomainEvent>
{
    private readonly EmployeeCreator _creator;

    public CreateVehicleEmployeeOnEmployeeCreated(EmployeeCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(EmployeeCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(notification.AggregateId, notification.FullName);
    }
}
