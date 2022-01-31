using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Parcels.Application.Create;

public class CreateParcelCommandHandler : CommandHandler<CreateParcelCommand>
{
    private readonly ParcelCreator _creator;

    public CreateParcelCommandHandler(ParcelCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateParcelCommand request, CancellationToken cancellationToken)
    {
        await _creator.Create(request);
    }
}
