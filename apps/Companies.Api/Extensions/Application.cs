using Rusell.Companies.Application.Create;
using Rusell.Companies.Application.Find;
using Rusell.Companies.Application.FindByNit;

namespace Rusell.Companies.Api.Extensions;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<CompanyFinder, CompanyFinder>();
        services.AddScoped<CompanyByNitFinder, CompanyByNitFinder>();

        return services;
    }
}
