using Rusell.Clients.Domain;
using Rusell.Clients.Infrastructure.Persistence;
using Rusell.Clients.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Clients.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<ClientsDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Clients));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddMapping(Assemblies.Clients)
            .AddRabbitMq(configuration);

        return services;
    }
}
