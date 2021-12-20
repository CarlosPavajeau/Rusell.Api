using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Employees.Application.Create;

public class CreateEmployeeCommandHandler : CommandHandler<CreateEmployeeCommand>
{
    private readonly EmployeeCreator _creator;

    public CreateEmployeeCommandHandler(EmployeeCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _creator.Create(request);
    }
}
