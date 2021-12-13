using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Addresses.Api;
using Rusell.Addresses.Domain;
using Rusell.Addresses.Infrastructure.Persistence;
using Rusell.Addresses.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Test.Addresses;

public class AddressesContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AddressesDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Addresses));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<AddressesDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<AddressesDbContext, AddressesDbContext>();
            services.AddScoped<DbContext, AddressesDbContext>();
            services.AddScoped<IAddressesRepository, MySqlAddressesRepository>();
        };
    }
}
