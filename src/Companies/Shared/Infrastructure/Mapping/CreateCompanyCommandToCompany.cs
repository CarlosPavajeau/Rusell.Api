using Mapster;
using Rusell.Companies.Application.Create;
using Rusell.Companies.Domain;

namespace Rusell.Companies.Shared.Infrastructure.Mapping;

public class CreateCompanyCommandToCompany : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCompanyCommand, Company>()
            .MapWith(s => Company.Create(s.Name, s.Nit, s.Info, s.UserId));
    }
}
