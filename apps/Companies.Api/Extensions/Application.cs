using Rusell.Companies.Application.Create;
using Rusell.Companies.Application.Find;
using Rusell.Companies.Application.FindByNit;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Companies.Api.Extensions;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<CompanyFinder, CompanyFinder>();
        services.AddScoped<CompanyByNitFinder, CompanyByNitFinder>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Companies));

        return services;
    }
}
