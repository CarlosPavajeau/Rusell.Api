using Mapster;
using Rusell.Companies.Domain;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Shared.Domain.Companies.Domain;

namespace Rusell.Companies.Application.Create;

public class CompanyCreator
{
    private readonly ICompaniesRepository _repository;
    private readonly IEventBus _eventBus;

    public CompanyCreator(ICompaniesRepository repository, IEventBus eventBus)
    {
        _repository = repository;
        _eventBus = eventBus;
    }

    public async Task Create(CreateCompanyCommand command)
    {
        var company = command.Adapt<Company>();
        company.Record(new CompanyCreatedDomainEvent(company.Id.Value.ToString(), company.Name));

        await _repository.Save(company);
        await _eventBus.Publish(company.PullDomainEvents());
    }
}
