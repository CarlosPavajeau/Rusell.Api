using MediatR;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Addresses.Infrastructure.Persistence;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Companies.Infrastructure.Persistence;
using Rusell.Routes.Domain;
using Rusell.Routes.Infrastructure.Persistence;
using Rusell.Routes.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Routes.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<RoutesDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Routes));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IAddressesRepository, EntityFrameworkAddressesRepository>();
        services.AddScoped<IRoutesRepository, EntityFrameworkRoutesRepository>();
        services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddRabbitMq(configuration);

        services.AddHostedService<RabbitMqBusSubscriber>();

        return services;
    }
}
