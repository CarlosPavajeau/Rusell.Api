using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Employees.Api;
using Rusell.Employees.Domain;
using Rusell.Employees.Infrastructure.Persistence;
using Rusell.Employees.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Employees;

public class EmployeesContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EmployeesDbContext>));
            if (descriptor is not null) services.Remove(descriptor);

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Employees));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<EmployeesDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<EmployeesDbContext, EmployeesDbContext>();
            services.AddScoped<DbContext, EmployeesDbContext>();
            services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        };
    }
}
