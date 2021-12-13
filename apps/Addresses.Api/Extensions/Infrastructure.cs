using MediatR;
using Microsoft.EntityFrameworkCore;
using Rusell.Addresses.Domain;
using Rusell.Addresses.Infrastructure.Persistence;
using Rusell.Addresses.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Addresses.Api.Extensions;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AddressesDbContext>(options =>
        {
            options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 26)),
                    builder => { builder.CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds); })
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);
        services.AddScoped<AddressesDbContext, AddressesDbContext>();
        services.AddScoped<DbContext, AddressesDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Addresses));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IAddressesRepository, MySqlAddressesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        return services;
    }
}
