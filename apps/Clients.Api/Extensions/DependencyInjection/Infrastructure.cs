using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        services.AddDbContext<ClientsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<ClientsDbContext, ClientsDbContext>();
        services.AddScoped<DbContext, ClientsDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Clients));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddRabbitMq(configuration);

        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Clients));

        return services;
    }

    private static void AddBearerTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
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
