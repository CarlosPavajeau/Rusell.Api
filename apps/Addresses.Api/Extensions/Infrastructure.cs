using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

    services.AddScoped<IAddressesRepository, MySqlAddressesRepository>();
    services.AddScoped<IUnitWork, UnitWork>();

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
}