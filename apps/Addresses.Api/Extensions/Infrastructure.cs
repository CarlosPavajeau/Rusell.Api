using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rusell.Addresses.Domain;
using Rusell.Addresses.Infrastructure.Persistence;
using Rusell.Addresses.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.Addresses.Api.Extensions;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);

        services.AddDbContext<AddressesDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        });

        services.AddScoped<AddressesDbContext, AddressesDbContext>();
        services.AddScoped<DbContext, AddressesDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Addresses));
        services.AddMediatR(typeof(global::Program));

        services.AddScoped<IAddressesRepository, EntityFrameworkAddressesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddScoped<IEventBus, RabbitMqEventBus>();
        services.AddScoped<IEventBusConfiguration, RabbitMqEventBusConfiguration>();
        services.AddScoped<RabbitMqDomainEventsConsumer, RabbitMqDomainEventsConsumer>();
        services.AddScoped<DomainEventsInformation, DomainEventsInformation>();

        services.AddRabbitMq(configuration);
        services.AddScoped<IDomainEventDeserializer, DomainEventJsonDeserializer>();

        return services;
    }

    private static void AddBearerTokenAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
            {
                c.Authority = $"https://{configuration["Auth0:Domain"]}/";
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = configuration["Auth0:Audience"],
                    ValidIssuer = $"{configuration["Auth0:Domain"]}"
                };
            });
    }

    private static void AddRabbitMq(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<RabbitMqPublisher, RabbitMqPublisher>();
        services.AddScoped<RabbitMqConfig, RabbitMqConfig>();
        services.Configure<RabbitMqConfigParams>(configuration.GetSection("RabbitMq"));
    }
}
