using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Addresses.Infrastructure.Persistence;
using Rusell.Routes.Api;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Companies.Infrastructure.Persistence;
using Rusell.Routes.Domain;
using Rusell.Routes.Infrastructure.Persistence;
using Rusell.Routes.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Routes;

public class RoutesContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<RoutesDbContext>));
            if (descriptor is not null) services.Remove(descriptor);

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Routes));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<RoutesDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<RoutesDbContext, RoutesDbContext>();
            services.AddScoped<DbContext, RoutesDbContext>();
            services.AddScoped<IRoutesRepository, EntityFrameworkRoutesRepository>();
            services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
            services.AddScoped<IAddressesRepository, EntityFrameworkAddressesRepository>();
        };
    }
}
