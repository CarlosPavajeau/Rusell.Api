using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Vehicles.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Vehicles));

        return services;
    }
}
