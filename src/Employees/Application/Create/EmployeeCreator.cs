using Mapster;
using Rusell.Employees.Domain;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Employees.Application.Create;

public class EmployeeCreator
{
    private readonly IEventBus _eventBus;
    private readonly IEmployeesRepository _repository;

    public EmployeeCreator(IEmployeesRepository repository, IEventBus eventBus)
    {
        _repository = repository;
        _eventBus = eventBus;
    }

    public async Task Create(CreateEmployeeCommand command)
    {
        var employee = command.Adapt<Employee>();
        await _repository.Save(employee);

        await _eventBus.Publish(employee.PullDomainEvents());
    }
}
