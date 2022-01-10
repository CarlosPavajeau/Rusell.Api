using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Infrastructure.Bus.Event;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

namespace Rusell.Shared.Extensions.DependencyInjection;

public static class SharedInfrastructure
{
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<RabbitMqPublisher, RabbitMqPublisher>();
        services.AddScoped<RabbitMqConfig, RabbitMqConfig>();
        services.Configure<RabbitMqConfigParams>(configuration.GetSection("RabbitMq"));

        services.AddScoped<IEventBus, RabbitMqEventBus>();
        services.AddScoped<IEventBusConfiguration, RabbitMqEventBusConfiguration>();
        services.AddScoped<IDomainEventsConsumer, RabbitMqDomainEventsConsumer>();
        services.AddScoped<DomainEventsInformation, DomainEventsInformation>();

        services.AddScoped<IDomainEventDeserializer, DomainEventJsonDeserializer>();
    }
}
