using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Parcels.Api;
using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Clients.Infrastructure.Persistence;
using Rusell.Parcels.Domain;
using Rusell.Parcels.Employees.Domain;
using Rusell.Parcels.Employees.Infrastructure.Persistence;
using Rusell.Parcels.Infrastructure.Persistence;
using Rusell.Parcels.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Persistence;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Parcels;

public class ParcelsContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ParcelsDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Parcels));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<ParcelsDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<ParcelsDbContext, ParcelsDbContext>();
            services.AddScoped<DbContext, ParcelsDbContext>();
            services.AddScoped<IParcelsRepository, EntityFrameworkParcelsRepository>();
            services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
            services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
            services.AddScoped<IUnitWork, UnitWork>();
        };
    }
}
