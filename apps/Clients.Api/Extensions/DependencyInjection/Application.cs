using Rusell.Clients.Application.Find;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Clients.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ClientCreator, ClientCreator>();
        services.AddScoped<ClientFinder, ClientFinder>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Clients));

        return services;
    }
}
