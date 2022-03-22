using Mapster;
using Rusell.Companies.Domain;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Companies.Application.Create;

public class CompanyCreator
{
    private readonly IEventBus _eventBus;
    private readonly ICompaniesRepository _repository;

    public CompanyCreator(ICompaniesRepository repository, IEventBus eventBus)
    {
        _repository = repository;
        _eventBus = eventBus;
    }

    public async Task Create(CreateCompanyCommand command)
    {
        var company = command.Adapt<Company>();

        await _repository.Save(company);
        await _eventBus.Publish(company.PullDomainEvents());
    }
}
