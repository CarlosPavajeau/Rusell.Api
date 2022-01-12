using Rusell.Vehicles.Api.Grpc.Models;

namespace Rusell.Vehicles.Api.Grpc;

public interface IEmployeesService
{
    Task<IEnumerable<Employee>> SearchAll();
}
