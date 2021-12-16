using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Infrastructure.Bus.Event;

public class DomainEventsInformation
{
    private readonly Dictionary<string, Type> _indexedDomainEvents = new();

    public DomainEventsInformation()
    {
        GetDomainTypes().ForEach(eventType =>
            _indexedDomainEvents.Add(GetEventName(eventType) ?? throw new InvalidOperationException(), eventType));
    }

    public Type? ForName(string name)
    {
        _indexedDomainEvents.TryGetValue(name, out var value);
        return value;
    }

    public string ForClass(DomainEvent domainEvent)
    {
        return _indexedDomainEvents.FirstOrDefault(x => x.Value == domainEvent.GetType()).Key;
    }

    private static string? GetEventName(Type eventType)
    {
        var instance = (DomainEvent?) Activator.CreateInstance(eventType);
        return eventType.GetMethod("EventName")?.Invoke(instance, null)?.ToString();
    }

    private static List<Type> GetDomainTypes()
    {
        var type = typeof(DomainEvent);

        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract).ToList();
    }
}
