using Mapster;
using Rusell.Employees.Api;
using Rusell.Vehicles.Api.Grpc.Models;

namespace Rusell.Vehicles.Api.Grpc;

public class EmployeesService : IEmployeesService
{
    private readonly GrpcEmployees.GrpcEmployeesClient _client;
    private readonly ILogger<EmployeesService> _logger;

    public EmployeesService(GrpcEmployees.GrpcEmployeesClient client, ILogger<EmployeesService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<IEnumerable<Employee>> SearchAll()
    {
        try
        {
            var request = new SearchAllEmployeesRequest();
            var response = await _client.SearchAllEmployeesAsync(request);

            return response.Employees.Adapt<IEnumerable<Employee>>();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while searching all employees");
            return ArraySegment<Employee>.Empty;
        }
    }
}
