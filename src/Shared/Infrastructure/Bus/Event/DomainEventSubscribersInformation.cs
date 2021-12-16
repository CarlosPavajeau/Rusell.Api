namespace Rusell.Shared.Infrastructure.Bus.Event;

public class DomainEventSubscribersInformation
{
    private readonly Dictionary<Type, DomainEventSubscriberInformation> _information;

    public DomainEventSubscribersInformation(Dictionary<Type, DomainEventSubscriberInformation> information)
    {
        _information = information;
    }

    public Dictionary<Type, DomainEventSubscriberInformation>.ValueCollection All() => _information.Values;

    public List<string> RabbitMqFormattedNames()
    {
        return _information.Values.Select(x => x.FormatRabbitMqQueueName()).ToList();
    }
}
