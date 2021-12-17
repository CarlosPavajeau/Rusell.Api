using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Domain.Address.Domain;

public class AddressCreatedDomainEvent : DomainEvent
{
    public string Country { get; }
    public string State { get; }
    public string City { get; }


    public AddressCreatedDomainEvent(string id, string country, string state, string city, string? eventId = null,
        string? occurredOn = null) : base(id, eventId, occurredOn)
    {
        Country = country;
        State = state;
        City = city;
    }

    public AddressCreatedDomainEvent()
    {
    }

    public override string EventName() => "address.created";

    public override Dictionary<string, string> ToPrimitives() => new()
    {
        {"country", Country},
        {"state", State},
        {"city", City}
    };

    public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
        string occurredOn) => new AddressCreatedDomainEvent(aggregateId, body["country"], body["state"], body["city"],
        eventId, occurredOn);
}
