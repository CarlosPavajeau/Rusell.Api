using Rusell.Companies.Application.Create;
using Rusell.Companies.Application.Find;
using Rusell.Companies.Application.FindByNit;
using Rusell.Companies.Application.FindByUser;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Companies.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<CompanyFinder, CompanyFinder>();
        services.AddScoped<CompanyByNitFinder, CompanyByNitFinder>();
        services.AddScoped<CompanyByUserFinder, CompanyByUserFinder>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Companies));

        return services;
    }
}
