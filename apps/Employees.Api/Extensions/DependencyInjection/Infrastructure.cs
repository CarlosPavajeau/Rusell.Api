using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rusell.Employees.Domain;
using Rusell.Employees.Infrastructure.Persistence;
using Rusell.Employees.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Employees.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);

        services.AddDbContext<EmployeesDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<EmployeesDbContext, EmployeesDbContext>();
        services.AddScoped<DbContext, EmployeesDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Employees));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddRabbitMq(configuration);

        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Employees));

        return services;
    }

    private static void AddBearerTokenAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                c =>
                {
                    c.Authority = $"https://{configuration["Auth0:Domain"]}/";
                    c.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = configuration["Auth0:Audience"],
                        ValidIssuer = $"{configuration["Auth0:Domain"]}"
                    };
                });
    }
}
