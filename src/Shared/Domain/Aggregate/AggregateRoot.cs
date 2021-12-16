using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Domain.Aggregate;

public abstract class AggregateRoot
{
    private List<DomainEvent> _domainEvents = new();

    public List<DomainEvent> PullDomainEvents()
    {
        var events = _domainEvents;
        _domainEvents = new List<DomainEvent>();

        return events;
    }

    public void Record(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
