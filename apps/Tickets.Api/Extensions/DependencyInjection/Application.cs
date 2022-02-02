using Rusell.Shared;
using Rusell.Shared.Helpers;
using Rusell.Tickets.Application.Create;
using Rusell.Tickets.Application.SearchAllByClient;
using Rusell.Tickets.Application.SearchAllByTransportSheet;
using Rusell.Tickets.Clients.Application.Create;

namespace Rusell.Tickets.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TicketCreator, TicketCreator>();
        services.AddScoped<TicketsByClientSearcher, TicketsByClientSearcher>();
        services.AddScoped<TicketsByTransportSheetSearcher, TicketsByTransportSheetSearcher>();

        services.AddScoped<ClientCreator, ClientCreator>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Tickets));

        return services;
    }
}
