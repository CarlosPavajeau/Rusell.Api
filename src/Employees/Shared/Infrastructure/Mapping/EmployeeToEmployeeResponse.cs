using Mapster;
using Rusell.Employees.Application;
using Rusell.Employees.Domain;

namespace Rusell.Employees.Shared.Infrastructure.Mapping;

public class EmployeeToEmployeeResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Employee, EmployeeResponse>()
            .MapWith(s => new EmployeeResponse(
                s.Id,
                $"{s.FirstName} {s.MiddleName} {s.FirstSurname} {s.SecondSurname}",
                s.Email,
                s.PhoneNumber,
                s.Type));
    }
}
