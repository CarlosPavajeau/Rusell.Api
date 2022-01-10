using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rusell.Employees.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Employees;

public class EmployeesWebApplicationFactory<TStartup> : ApplicationTestCase<TStartup> where TStartup : class
{
    private string _databaseName = Guid.NewGuid().ToString();

    private void SetDatabaseName()
    {
        _databaseName = Guid.NewGuid().ToString();
    }

    public HttpClient GetAuthenticatedClient()
    {
        SetDatabaseName();
        return CreateClient();
    }

    protected override Action<IServiceCollection> Services()
    {
        return services =>
        {
            // Create a new service provider.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Remove previous db context registration.
            services.RemoveAll(typeof(DbContextOptions<EmployeesDbContext>));

            // Add a database context using an in-memory 
            // database for testing.
            services.AddDbContext<EmployeesDbContext>(options =>
            {
                options.UseInMemoryDatabase(_databaseName);
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddAuthentication("Test")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                    "Test", options => { });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<EmployeesDbContext>();

            // Ensure the database is created.
            context.Database.EnsureCreated();
        };
    }
}
