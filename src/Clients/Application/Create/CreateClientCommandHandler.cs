using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Clients.Application.Create;

public class CreateClientCommandHandler : CommandHandler<CreateClientCommand>
{
    private readonly ClientCreator _creator;

    public CreateClientCommandHandler(ClientCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        await _creator.Create(request);
    }
}
