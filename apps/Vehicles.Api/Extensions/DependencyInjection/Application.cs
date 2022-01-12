using Rusell.Shared;
using Rusell.Shared.Helpers;
using Rusell.Vehicles.Application.Create;
using Rusell.Vehicles.Application.SearchAll;
using Rusell.Vehicles.Employees.Application.CheckExists;
using Rusell.Vehicles.Employees.Application.Create;

namespace Rusell.Vehicles.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<EmployeeCreator, EmployeeCreator>();
        services.AddScoped<EmployeeExistsChecker, EmployeeExistsChecker>();
        services.AddScoped<VehicleCreator, VehicleCreator>();
        services.AddScoped<VehiclesSearcher, VehiclesSearcher>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Vehicles));

        return services;
    }
}
