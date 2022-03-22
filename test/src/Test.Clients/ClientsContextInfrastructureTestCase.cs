using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Clients.Api;
using Rusell.Clients.Domain;
using Rusell.Clients.Infrastructure.Persistence;
using Rusell.Clients.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Clients;

public class ClientsContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ClientsDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Clients));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<ClientsDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<ClientsDbContext, ClientsDbContext>();
            services.AddScoped<DbContext, ClientsDbContext>();
            services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        };
    }
}
