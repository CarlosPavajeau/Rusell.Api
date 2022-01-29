using Rusell.Addresses.Application.Create;
using Rusell.Addresses.Application.Find;
using Rusell.Addresses.Application.SearchAllByUser;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Addresses.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddressCreator, AddressCreator>();
        services.AddScoped<AddressFinder, AddressFinder>();
        services.AddScoped<AddressesByUserSearcher, AddressesByUserSearcher>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Addresses));

        return services;
    }
}
