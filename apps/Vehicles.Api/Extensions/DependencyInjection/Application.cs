using Rusell.Shared;
using Rusell.Shared.Helpers;
using Rusell.Vehicles.Employees.Application.Create;

namespace Rusell.Vehicles.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<EmployeeCreator, EmployeeCreator>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Vehicles));

        return services;
    }
}
