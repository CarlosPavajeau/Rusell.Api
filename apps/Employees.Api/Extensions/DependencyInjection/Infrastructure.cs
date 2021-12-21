using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rusell.Employees.Domain;
using Rusell.Employees.Infrastructure.Persistence;
using Rusell.Employees.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
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

        services.AddScoped<IEventBus, RabbitMqEventBus>();
        services.AddScoped<IEventBusConfiguration, RabbitMqEventBusConfiguration>();
        services.AddScoped<RabbitMqDomainEventsConsumer, RabbitMqDomainEventsConsumer>();
        services.AddScoped<DomainEventsInformation, DomainEventsInformation>();

        services.AddRabbitMq(configuration);
        services.AddScoped<IDomainEventDeserializer, DomainEventJsonDeserializer>();

        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Employees));

        return services;
    }

    private static IServiceCollection AddBearerTokenAuthentication(this IServiceCollection services,
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

        return services;
    }

    private static void AddRabbitMq(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<RabbitMqPublisher, RabbitMqPublisher>();
        services.AddScoped<RabbitMqConfig, RabbitMqConfig>();
        services.Configure<RabbitMqConfigParams>(configuration.GetSection("RabbitMq"));
    }
}
