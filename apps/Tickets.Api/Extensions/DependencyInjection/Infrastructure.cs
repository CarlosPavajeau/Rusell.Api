using MediatR;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
using Rusell.Tickets.Clients.Domain;
using Rusell.Tickets.Clients.Infrastructure.Persistence;
using Rusell.Tickets.Domain;
using Rusell.Tickets.Infrastructure.Persistence;
using Rusell.Tickets.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.Tickets.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<TicketsDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Tickets));
        services.AddMediatR(typeof(Program));

        services.AddScoped<ITicketsRepository, EntityFrameworkTicketsRepository>();
        services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();

        services.AddMapping(Assemblies.Tickets)
            .AddRabbitMq(configuration);
        services.AddHostedService<RabbitMqBusSubscriber>();

        return services;
    }
}
