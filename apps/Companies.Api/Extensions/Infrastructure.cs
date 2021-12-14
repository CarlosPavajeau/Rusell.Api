using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    services.AddBearerTokenAuthentication(configuration);

    services.AddDbContext<CompaniesDbContext>(options =>
    {
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
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
}