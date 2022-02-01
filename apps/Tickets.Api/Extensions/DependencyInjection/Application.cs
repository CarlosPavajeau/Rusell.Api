using Rusell.Shared;
using Rusell.Shared.Helpers;
using Rusell.Tickets.Application.Create;
using Rusell.Tickets.Clients.Application.Create;

namespace Rusell.Tickets.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TicketCreator, TicketCreator>();

        services.AddScoped<ClientCreator, ClientCreator>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Tickets));

        return services;
    }
}
