using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Exceptions;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

public class RabbitMqEventBus : IEventBus
{
    private readonly string _exchangeName;
    private readonly ILogger<RabbitMqEventBus> _logger;
    private readonly RabbitMqPublisher _publisher;

    public RabbitMqEventBus(RabbitMqPublisher publisher, ILogger<RabbitMqEventBus> logger,
        string exchangeName = "domain_events")
    {
        _exchangeName = exchangeName;
        _publisher = publisher;
        _logger = logger;
    }

    public async Task Publish(List<DomainEvent> events)
    {
        foreach (var domainEvent in events) await Publish(domainEvent);
    }

    private Task Publish(DomainEvent domainEvent)
    {
        try
        {
            var serializedDomainEvent = DomainEventJsonSerializer.Serialize(domainEvent);
            _publisher.Publish(_exchangeName, domainEvent.EventName(), serializedDomainEvent);
        }
        catch (RabbitMQClientException e)
        {
            _logger.LogError(e, "Error publishing event: {Event}", domainEvent.EventName());
        }

        return Task.CompletedTask;
    }
}
