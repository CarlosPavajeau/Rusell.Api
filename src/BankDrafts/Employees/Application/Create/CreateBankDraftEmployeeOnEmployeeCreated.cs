using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Employees.Domain;

namespace Rusell.BankDrafts.Employees.Application.Create;

public class CreateBankDraftEmployeeOnEmployeeCreated : IDomainEventSubscriber<EmployeeCreatedDomainEvent>
{
    private readonly EmployeeCreator _creator;

    public CreateBankDraftEmployeeOnEmployeeCreated(EmployeeCreator creator)
    {
        _creator = creator;
    }

    public async Task Handle(EmployeeCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _creator.Create(notification.AggregateId, notification.FullName);
    }
}
