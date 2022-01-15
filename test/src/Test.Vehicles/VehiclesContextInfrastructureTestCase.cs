using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;
using Rusell.Vehicles.Api;
using Rusell.Vehicles.Domain;
using Rusell.Vehicles.Domain.LegalInformation;
using Rusell.Vehicles.Employees.Domain;
using Rusell.Vehicles.Employees.Infrastructure.Persistence;
using Rusell.Vehicles.Infrastructure.Persistence;
using Rusell.Vehicles.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.Test.Vehicles;

public class VehiclesContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<VehiclesDbContext>));
            if (descriptor is not null) services.Remove(descriptor);

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Vehicles));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<VehiclesDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<VehiclesDbContext, VehiclesDbContext>();
            services.AddScoped<DbContext, VehiclesDbContext>();
            services.AddScoped<IVehiclesRepository, EntityFrameworkVehiclesRepository>();
            services.AddScoped<ILegalInformationRepository, EntityFrameworkLegalInformationRepository>();
            services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        };
    }
}
