using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Vehicles.Employees.Application.Create;

public class CreateEmployeeCommandHandler : CommandHandler<CreateEmployeeCommand>
{
    private readonly EmployeeCreator _creator;

    public CreateEmployeeCommandHandler(EmployeeCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var (id, fullName) = request;
        await _creator.Create(id, fullName);
    }
}
