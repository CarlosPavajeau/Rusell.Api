using MediatR;
using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Clients.Infrastructure.Persistence;
using Rusell.Parcels.Companies.Domain;
using Rusell.Parcels.Companies.Infrastructure.Persistence;
using Rusell.Parcels.Domain;
using Rusell.Parcels.Employees.Domain;
using Rusell.Parcels.Employees.Infrastructure.Persistence;
using Rusell.Parcels.Infrastructure.Persistence;
using Rusell.Parcels.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

namespace Rusell.Parcels.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<ParcelsDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Parcels));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IParcelsRepository, EntityFrameworkParcelsRepository>();
        services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();

        services.AddMapping(Assemblies.Parcels)
            .AddRabbitMq(configuration);
        services.AddHostedService<RabbitMqBusSubscriber>();

        return services;
    }
}
