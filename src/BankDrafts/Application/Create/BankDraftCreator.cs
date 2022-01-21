using Mapster;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Application.Create;

public class BankDraftCreator
{
    private readonly IBankDraftsRepository _repository;

    public BankDraftCreator(IBankDraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateBankDraftCommand command)
    {
        var bankDraft = command.Adapt<BankDraft>();
        await _repository.Save(bankDraft);
    }
}
