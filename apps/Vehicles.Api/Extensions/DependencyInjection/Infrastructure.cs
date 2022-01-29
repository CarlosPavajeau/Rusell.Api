using MediatR;
using Rusell.Employees.Api;
using Rusell.Shared.Domain.Persistence;
using Rusell.Shared.Extensions.DependencyInjection;
using Rusell.Shared.Helpers;
using Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;
using Rusell.Shared.Infrastructure.Persistence;
using Rusell.Vehicles.Api.Grpc;
using Rusell.Vehicles.Api.HostedServices;
using Rusell.Vehicles.Domain;
using Rusell.Vehicles.Domain.LegalInformation;
using Rusell.Vehicles.Employees.Domain;
using Rusell.Vehicles.Employees.Infrastructure.Persistence;
using Rusell.Vehicles.Infrastructure.Persistence;
using Rusell.Vehicles.Shared.Infrastructure.Persistence.EntityFramework;

namespace Rusell.Vehicles.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBearerTokenAuthentication(configuration);
        services.AddDbContextNpgsql<VehiclesDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Vehicles));
        services.AddMediatR(typeof(Program));

        services.AddScoped<IEmployeesRepository, EntityFrameworkEmployeesRepository>();
        services.AddScoped<IVehiclesRepository, EntityFrameworkVehiclesRepository>();
        services.AddScoped<ILegalInformationRepository, EntityFrameworkLegalInformationRepository>();
        services.AddScoped<IUnitWork, UnitWork>();

        services.AddMapping(Assemblies.Vehicles)
            .AddRabbitMq(configuration);
        services.AddHostedService<RabbitMqBusSubscriber>();
        services.AddHostedService<SearchAndCreateEmployees>();

        services.AddGrpcClient<GrpcEmployees.GrpcEmployeesClient>((grpcServices, options) =>
        {
            var employeesApi = grpcServices.GetRequiredService<IConfiguration>()["GrpcEmployees"];
            options.Address = new Uri(employeesApi);
        });
        services.AddScoped<IEmployeesService, EmployeesService>();

        return services;
    }
}
