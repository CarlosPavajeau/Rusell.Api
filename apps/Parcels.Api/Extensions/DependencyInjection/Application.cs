using Rusell.Parcels.Application.Create;
using Rusell.Parcels.Application.SearchAllByReceiver;
using Rusell.Parcels.Application.SearchAllByReceiverAndState;
using Rusell.Parcels.Application.SearchAllBySender;
using Rusell.Parcels.Clients.Application.Create;
using Rusell.Parcels.Companies.Application.Create;
using Rusell.Parcels.Employees.Application.Create;
using Rusell.Shared;
using Rusell.Shared.Helpers;

namespace Rusell.Parcels.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ParcelCreator, ParcelCreator>();
        services.AddScoped<ParcelsByReceiverSearcher, ParcelsByReceiverSearcher>();
        services.AddScoped<ParcelsBySenderSearcher, ParcelsBySenderSearcher>();
        services.AddScoped<ParcelsByReceiverAndStateSearcher, ParcelsByReceiverAndStateSearcher>();

        services.AddScoped<ClientCreator, ClientCreator>();
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<EmployeeCreator, EmployeeCreator>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.Parcels));
        return services;
    }
}
