using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.BankDrafts.Application.Create;

public class CreateBankDraftCommandHandler : CommandHandler<CreateBankDraftCommand>
{
    private readonly BankDraftCreator _creator;

    public CreateBankDraftCommandHandler(BankDraftCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateBankDraftCommand request, CancellationToken cancellationToken)
    {
        await _creator.Create(request);
    }
}
