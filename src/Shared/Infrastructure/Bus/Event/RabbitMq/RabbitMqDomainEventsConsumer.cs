using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

public class RabbitMqDomainEventsConsumer : IDomainEventsConsumer
{
    private const int MaxRetries = 2;
    private const string HeaderRedelivery = "redelivery_count";
    private readonly RabbitMqConfig _config;
    private readonly IDomainEventDeserializer _deserializer;
    private readonly IServiceProvider _serviceProvider;

    private readonly DomainEventSubscribersInformation _information;

    public RabbitMqDomainEventsConsumer(RabbitMqConfig config, IServiceProvider serviceProvider,
        DomainEventSubscribersInformation information, IDomainEventDeserializer deserializer)
    {
        _config = config;
        _serviceProvider = serviceProvider;
        _information = information;
        _deserializer = deserializer;
    }


    public Task Consume()
    {
        _information.RabbitMqFormattedNames().ForEach(queue => ConsumeMessages(queue));
        return Task.CompletedTask;
    }

    private void ConsumeMessages(string queue, ushort prefetchCount = 10)
    {
        var channel = _config.Channel();

        DeclareQueue(channel, queue);

        channel.BasicQos(0, prefetchCount, false);
        var scope = _serviceProvider.CreateScope();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (_, ea) =>
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            var @event = _deserializer.Deserialize(message);

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            try
            {
                await mediator.Publish(@event);
            }
            catch
            {
                HandleConsumptionError(ea, @event, queue);
            }

            channel.BasicAck(ea.DeliveryTag, false);
        };

        _ = channel.BasicConsume(queue, false, consumer);
    }

    private static void DeclareQueue(IModel channel, string queue)
    {
        channel.QueueDeclare(queue,
            true,
            false,
            false
        );
    }

    private void HandleConsumptionError(BasicDeliverEventArgs ea, DomainEvent @event, string queue)
    {
        if (HasBeenRedeliveredTooMuch(ea.BasicProperties.Headers))
            SendToDeadLetter(ea, queue);
        else
            SendToRetry(ea, queue);
    }

    private static bool HasBeenRedeliveredTooMuch(IDictionary<string, object> headers) =>
        (int) (headers[HeaderRedelivery] ?? 0) >= MaxRetries;

    private void SendToRetry(BasicDeliverEventArgs ea, string queue)
    {
        SendMessageTo(RabbitMqExchangeNameFormatter.Retry("domain_events"), ea, queue);
    }

    private void SendToDeadLetter(BasicDeliverEventArgs ea, string queue)
    {
        SendMessageTo(RabbitMqExchangeNameFormatter.DeadLetter("domain_events"), ea, queue);
    }

    private void SendMessageTo(string exchange, BasicDeliverEventArgs ea, string queue)
    {
        var channel = _config.Channel();
        channel.ExchangeDeclare(exchange, ExchangeType.Topic);

        var body = ea.Body;
        var properties = ea.BasicProperties;
        var headers = ea.BasicProperties.Headers;
        headers[HeaderRedelivery] = (int) headers[HeaderRedelivery] + 1;
        properties.Headers = headers;

        channel.BasicPublish(exchange,
            queue,
            properties,
            body);
    }
}
