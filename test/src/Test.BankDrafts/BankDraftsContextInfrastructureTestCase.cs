using System;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rusell.BankDrafts.Api;
using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Clients.Infrastructure.Persistence;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Companies.Infrastructure.Persistence;
using Rusell.BankDrafts.Domain;
using Rusell.BankDrafts.Employees.Domain;
using Rusell.BankDrafts.Employees.Infrastructure.Persistence;
using Rusell.BankDrafts.Infrastructure.Persistence;
using Rusell.BankDrafts.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.BankDrafts;

public class BankDraftsContextInfrastructureTestCase : InfrastructureTestCase<Program>
{
    protected override void Setup()
    {
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BankDraftsDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.BankDrafts));

            var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<BankDraftsDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<BankDraftsDbContext, BankDraftsDbContext>();
            services.AddScoped<DbContext, BankDraftsDbContext>();
            services.AddScoped<IBankDraftsRepository, EntityFrameworkBankDraftsRepository>();
            services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
            services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
            services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        };
    }
}
