using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

public class RabbitMqBusSubscriber : BackgroundService
{
    private readonly IServiceProvider _provider;

    public RabbitMqBusSubscriber(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        using var scope = _provider.CreateScope();

        var consumer = scope.ServiceProvider.GetRequiredService<IDomainEventsConsumer>();
        var configuration = scope.ServiceProvider.GetRequiredService<IEventBusConfiguration>();

        configuration.Configure();
        return consumer.Consume();
    }
}
