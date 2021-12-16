using System.Globalization;
using MediatR;

namespace Rusell.Shared.Domain.Bus.Event;

public abstract class DomainEvent : INotification
{
    protected DomainEvent(string aggregateId, string? eventId, string? occurredOn)
    {
        AggregateId = aggregateId;
        EventId = eventId ?? Guid.NewGuid().ToString();
        OccurredOn = occurredOn ?? DateTime.Now.ToString("s", CultureInfo.CurrentCulture);
    }

    protected DomainEvent()
    {
    }

    public string AggregateId { get; }
    public string EventId { get; }
    public string OccurredOn { get; }

    public abstract string EventName();

    public abstract Dictionary<string, string> ToPrimitives();

    public abstract DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
        string occurredOn);
}
