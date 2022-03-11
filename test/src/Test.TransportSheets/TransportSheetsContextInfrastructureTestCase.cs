using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;
using Rusell.TransportSheets.Api;
using Rusell.TransportSheets.Domain;
using Rusell.TransportSheets.Employees.Domain;
using Rusell.TransportSheets.Employees.Infrastructure.Persistence;
using Rusell.TransportSheets.Infrastructure.Persistence;
using Rusell.TransportSheets.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.Test.TransportSheets;

public class TransportSheetsContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TransportSheetsDbContext>));
            if (descriptor is not null) services.Remove(descriptor);

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.TransportSheets));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<TransportSheetsDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<TransportSheetsDbContext, TransportSheetsDbContext>();
            services.AddScoped<DbContext, TransportSheetsDbContext>();
            services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
            services.AddScoped<ITransportSheetsRepository, EntityFrameworkTransportSheetsRepository>();
        };
    }
}
