using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Companies.Api;
using Rusell.Companies.Domain;
using Rusell.Companies.Infrastructure.Persistence;
using Rusell.Companies.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;
using AssemblyHelper = Rusell.Shared.Helpers.AssemblyHelper;

namespace Rusell.Test.Companies;

public class CompaniesContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CompaniesDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Companies));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<CompaniesDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<CompaniesDbContext, CompaniesDbContext>();
            services.AddScoped<DbContext, CompaniesDbContext>();
            services.AddScoped<ICompaniesRepository, MySqlCompaniesRepository>();
        };
    }
}
