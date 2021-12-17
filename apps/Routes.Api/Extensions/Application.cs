using Rusell.Routes.Addresses.Application.Create;
using Rusell.Routes.Application.Create;
using Rusell.Routes.Application.SearchAllByCompany;
using Rusell.Routes.Companies.Application.Create;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Routes.Api.Extensions;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddressCreator, AddressCreator>();
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<RouteCreator, RouteCreator>();
        services.AddScoped<RoutesByCompanySearcher, RoutesByCompanySearcher>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Routes));
        return services;
    }
}
