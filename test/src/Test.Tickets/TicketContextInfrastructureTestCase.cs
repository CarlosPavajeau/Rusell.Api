using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;
using Rusell.Tickets.Api;
using Rusell.Tickets.Clients.Domain;
using Rusell.Tickets.Clients.Infrastructure.Persistence;
using Rusell.Tickets.Domain;
using Rusell.Tickets.Infrastructure.Persistence;
using Rusell.Tickets.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.Test.Tickets;

public class TicketContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TicketsDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Tickets));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<TicketsDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<TicketsDbContext, TicketsDbContext>();
            services.AddScoped<DbContext, TicketsDbContext>();
            services.AddScoped<ITicketsRepository, EntityFrameworkTicketsRepository>();
            services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        };
    }
}
