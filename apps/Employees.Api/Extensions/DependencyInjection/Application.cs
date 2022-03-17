using Rusell.Employees.Application.Create;
using Rusell.Employees.Application.FindByUser;
using Rusell.Employees.Application.SearchAll;
using Rusell.Employees.Application.SearchAllByCompany;
using Rusell.Employees.Application.SearchAllByType;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Employees.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<EmployeeCreator, EmployeeCreator>();
        services.AddScoped<EmployeesByCompanySearcher, EmployeesByCompanySearcher>();
        services.AddScoped<CompanyEmployeesByTypeSearcher, CompanyEmployeesByTypeSearcher>();
        services.AddScoped<EmployeesSearcher, EmployeesSearcher>();
        services.AddScoped<EmployeeByUserFinder, EmployeeByUserFinder>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Employees));

        return services;
    }
}
