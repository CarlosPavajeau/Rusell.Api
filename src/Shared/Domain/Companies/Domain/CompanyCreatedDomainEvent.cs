using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Domain.Companies.Domain;

public class CompanyCreatedDomainEvent : DomainEvent
{
    public CompanyCreatedDomainEvent(string id, string name, string? eventId = null,
        string? occurredOn = null) : base(id, eventId, occurredOn)
    {
        Name = name;
    }

    public CompanyCreatedDomainEvent()
    {
    }

    public string Name { get; }

    public override string EventName() => "company.created";

    public override Dictionary<string, string> ToPrimitives() =>
        new()
        {
            {"name", Name}
        };

    public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
        string occurredOn) =>
        new CompanyCreatedDomainEvent(aggregateId, body["name"]);
}
