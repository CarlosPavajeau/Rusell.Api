using MediatR;

namespace Rusell.Shared.Domain.Bus.Event;

public abstract class DomainEvent : INotification
{
    protected DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; }
    public Guid AggregateId { get; }
}