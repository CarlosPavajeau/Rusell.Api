using MediatR;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
using Rusell.TransportSheets.Domain;
using Rusell.TransportSheets.Employees.Domain;
using Rusell.TransportSheets.Employees.Infrastructure.Persistence;
using Rusell.TransportSheets.Infrastructure.Persistence;
using Rusell.TransportSheets.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.TransportSheets.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<TransportSheetsDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.TransportSheets));
        services.AddMediatR(typeof(Program));

        services.AddScoped<ITransportSheetsRepository, EntityFrameworkTransportSheetsRepository>();
        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();

        services.AddMapping(Assemblies.TransportSheets)
            .AddRabbitMq(configuration);
        services.AddHostedService<RabbitMqBusSubscriber>();

        return services;
    }
}
