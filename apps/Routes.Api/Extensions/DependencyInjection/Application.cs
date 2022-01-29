using Rusell.Routes.Addresses.Application.Create;
using Rusell.Routes.Application.Create;
using Rusell.Routes.Application.SearchAllByCompany;
using Rusell.Routes.Application.SearchAllByFromTo;
using Rusell.Routes.Companies.Application.Create;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Routes.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddressCreator, AddressCreator>();
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<RouteCreator, RouteCreator>();
        services.AddScoped<RoutesByCompanySearcher, RoutesByCompanySearcher>();
        services.AddScoped<RoutesByFromToSearcher, RoutesByFromToSearcher>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Routes));
        return services;
    }
}
