using Rusell.Addresses.Application.Create;
using Rusell.Addresses.Application.Find;
using Rusell.Addresses.Application.SearchAllByUser;

namespace Rusell.Addresses.Api.Extensions;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddressCreator, AddressCreator>();
        services.AddScoped<AddressFinder, AddressFinder>();
        services.AddScoped<AddressesByUserSearcher, AddressesByUserSearcher>();

        return services;
    }
}