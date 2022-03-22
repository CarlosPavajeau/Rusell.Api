using Rusell.Shared.Extensions;

namespace Rusell.Shared.Infrastructure.Bus.Event;

public class DomainEventSubscriberInformation
{
    private readonly Type _subscriberClass;

    public DomainEventSubscriberInformation(Type subscriberClass, Type subscribedEvent)
    {
        SubscribedEvent = subscribedEvent;
        _subscriberClass = subscriberClass;
    }

    public Type SubscribedEvent { get; }

    public string ContextName
    {
        get
        {
            var nameParts = _subscriberClass.FullName?.Split(".");
            return nameParts?[1];
        }
    }

    public string ModuleName
    {
        get
        {
            var nameParts = _subscriberClass.FullName?.Split(".");
            return nameParts?[2];
        }
    }

    public string ClassName
    {
        get
        {
            var nameParts = _subscriberClass.FullName?.Split(".");
            return nameParts?[^1];
        }
    }

    public string FormatRabbitMqQueueName() =>
        $"rusell.{ContextName.ToSnake()}.{ModuleName.ToSnake()}.{ClassName.ToSnake()}";
}
