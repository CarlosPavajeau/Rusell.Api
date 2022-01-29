using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Parcels.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Parcels));
        return services;
    }
}
