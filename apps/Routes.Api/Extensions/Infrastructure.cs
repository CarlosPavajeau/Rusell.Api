using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

namespace Rusell.Routes.Api.Extensions;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);

        services.AddDbContext<RoutesDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<RoutesDbContext, RoutesDbContext>();
        services.AddScoped<DbContext, RoutesDbContext>();

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
