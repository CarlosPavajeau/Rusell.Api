using MediatR;
using Rusell.Companies.Domain;
using Rusell.Companies.Infrastructure.Persistence;
using Rusell.Companies.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Companies.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<CompaniesDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Companies));
        services.AddMediatR(typeof(Program));

        services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddMapping(Assemblies.Companies)
            .AddRabbitMq(configuration);

        return services;
    }
}
