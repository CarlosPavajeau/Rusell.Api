using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Clients.Infrastructure.Persistence;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Companies.Infrastructure.Persistence;
using Rusell.BankDrafts.Domain;
using Rusell.BankDrafts.Employees.Domain;
using Rusell.BankDrafts.Employees.Infrastructure.Persistence;
using Rusell.BankDrafts.Infrastructure.Persistence;
using Rusell.BankDrafts.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Infrastructure.Persistence;

namespace Rusell.BankDrafts.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);

        services.AddDbContext<BankDraftsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<BankDraftsDbContext, BankDraftsDbContext>();
        services.AddScoped<DbContext, BankDraftsDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.BankDrafts));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IBankDraftsRepository, EntityFrameworkBankDraftsRepository>();
        services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddRabbitMq(configuration);

        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.BankDrafts));

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
