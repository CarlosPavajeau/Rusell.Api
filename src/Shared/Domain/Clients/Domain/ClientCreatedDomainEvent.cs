using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Domain.Clients.Domain;

public class ClientCreatedDomainEvent : DomainEvent
{
    public ClientCreatedDomainEvent(string id, string fullName, string? eventId = null, string? occurredOn = null) :
        base(id,
            eventId, occurredOn)
    {
        FullName = fullName;
    }

    public ClientCreatedDomainEvent()
    {
    }

    public string FullName { get; } = default!;
    public override string EventName() => "client.created";

    public override Dictionary<string, string> ToPrimitives() => new()
    {
        {
            "fullName", FullName
        }
    };

    public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
        string occurredOn) => new ClientCreatedDomainEvent(aggregateId, body["fullName"], eventId, occurredOn);
}
