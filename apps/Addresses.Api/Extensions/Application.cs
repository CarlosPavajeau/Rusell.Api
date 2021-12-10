using Rusell.Addresses.Application.Create;
using Rusell.Addresses.Application.Find;
using Rusell.Addresses.Application.SearchAll;

namespace Addresses.Api.Extensions;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddressCreator, AddressCreator>();
        services.AddScoped<AddressesSearcher, AddressesSearcher>();
        services.AddScoped<AddressFinder, AddressFinder>();

        return services;
    }
}
