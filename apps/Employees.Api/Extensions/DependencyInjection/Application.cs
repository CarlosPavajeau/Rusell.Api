using Rusell.Employees.Application.Create;
using Rusell.Employees.Application.SearchAllByCompany;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Employees.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<EmployeeCreator, EmployeeCreator>();
        services.AddScoped<EmployeesByCompanySearcher, EmployeesByCompanySearcher>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Employees));

        return services;
    }
}
