using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Clients.Infrastructure.Persistence;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Companies.Infrastructure.Persistence;
using Rusell.BankDrafts.Domain;
using Rusell.BankDrafts.Employees.Domain;
using Rusell.BankDrafts.Employees.Infrastructure.Persistence;
using Rusell.BankDrafts.Infrastructure.Persistence;
using Rusell.BankDrafts.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.BankDrafts.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<BankDraftsDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.BankDrafts));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IBankDraftsRepository, EntityFrameworkBankDraftsRepository>();
        services.AddScoped<IClientsRepository, EntityFrameworkClientsRepository>();
        services.AddScoped<ICompaniesRepository, EntityFrameworkCompaniesRepository>();
        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddMapping(Assemblies.BankDrafts)
            .AddRabbitMq(configuration);
        services.AddHostedService<RabbitMqBusSubscriber>();

        return services;
    }
}
