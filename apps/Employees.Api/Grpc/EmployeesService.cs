using Grpc.Core;
using Mapster;
using MediatR;
using Rusell.Employees.Application.SearchAll;

namespace Rusell.Employees.Api.Grpc;

public class EmployeesService : GrpcEmployees.GrpcEmployeesBase
{
    private readonly IMediator _mediator;

    public EmployeesService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<SearchAllEmployeesResponse> SearchAllEmployees(SearchAllEmployeesRequest request,
        ServerCallContext context)
    {
        var employees = await _mediator.Send(new SearchAllEmployeesQuery());

        var response = new SearchAllEmployeesResponse();
        response.Employees.AddRange(employees.Adapt<IEnumerable<GrpcEmployee>>());

        return response;
    }
}
