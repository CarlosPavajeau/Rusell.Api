using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;

namespace Rusell.Tickets.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Tickets));
        services.AddMediatR(typeof(Program));

        services.AddMapping(Assemblies.Tickets)
            .AddRabbitMq(configuration);

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
