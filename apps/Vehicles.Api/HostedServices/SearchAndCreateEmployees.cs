using MediatR;
using Rusell.Vehicles.Api.Grpc;
using Rusell.Vehicles.Employees.Application.CheckExists;
using Rusell.Vehicles.Employees.Application.Create;

namespace Rusell.Vehicles.Api.HostedServices;

public class SearchAndCreateEmployees : BackgroundService
{
    private readonly IServiceProvider _provider;

    public SearchAndCreateEmployees(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = _provider.CreateScope();

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<SearchAndCreateEmployees>>();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var employeesService = scope.ServiceProvider.GetRequiredService<IEmployeesService>();

        var employees = await employeesService.SearchAll();
        foreach (var (id, fullName) in employees)
            try
            {
                var employeeExists = await mediator.Send(new CheckEmployeeExistsQuery(id), stoppingToken);
                if (!employeeExists)
                {
                    await mediator.Send(new CreateEmployeeCommand(id, fullName), stoppingToken);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while creating employee {Id}", id);
            }
    }
}
