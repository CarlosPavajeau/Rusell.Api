using MediatR;
using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Domain;
using Rusell.Companies.Infrastructure.Persistence;
using Rusell.Companies.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Companies.Api.Extensions;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CompaniesDbContext>(options =>
        {
            options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 26)),
                    builder => { builder.CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds); })
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<CompaniesDbContext, CompaniesDbContext>();
        services.AddScoped<DbContext, CompaniesDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Companies));
        services.AddMediatR(typeof(Program));

        services.AddScoped<ICompaniesRepository, MySqlCompaniesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        return services;
    }
}
