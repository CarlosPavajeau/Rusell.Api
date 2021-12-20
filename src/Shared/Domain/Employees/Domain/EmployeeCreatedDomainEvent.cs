using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Domain.Employees.Domain;

public class EmployeeCreatedDomainEvent : DomainEvent
{
    public string FullName { get; }

    public EmployeeCreatedDomainEvent(string id, string fullName, string? eventId = null, string? occurredOn = null) :
        base(id, eventId, occurredOn)
    {
        FullName = fullName;
    }

    public EmployeeCreatedDomainEvent()
    {
    }

    public override string EventName() => "employee.created";

    public override Dictionary<string, string> ToPrimitives() => new()
    {
        {
            "fullName", FullName
        }
    };

    public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
        string occurredOn) => new EmployeeCreatedDomainEvent(aggregateId, body["fullName"], eventId, occurredOn);
}
