using Mapster;
using Rusell.Employees.Application.Create;
using Rusell.Employees.Domain;

namespace Rusell.Employees.Shared.Infrastructure.Mapping;

public class CreateEmployeeCommandToEmployee : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateEmployeeCommand, Employee>()
            .MapWith(s =>
                Employee.Create(
                    s.Id,
                    s.FirstName,
                    s.MiddleName,
                    s.FirstSurname,
                    s.SecondSurname,
                    s.Email,
                    s.PhoneNumber,
                    s.Type,
                    s.CompanyId));
    }
}
