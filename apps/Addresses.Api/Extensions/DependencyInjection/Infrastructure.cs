using MediatR;
using Rusell.Addresses.Domain;
using Rusell.Addresses.Infrastructure.Persistence;
using Rusell.Addresses.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Addresses.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<AddressesDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Addresses));
        services.AddMediatR(typeof(global::Program));

        services.AddScoped<IAddressesRepository, EntityFrameworkAddressesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddRabbitMq(configuration);

        return services;
    }
}
