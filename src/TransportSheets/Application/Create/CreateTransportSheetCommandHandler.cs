using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.TransportSheets.Application.Create;

public class CreateTransportSheetCommandHandler : ICommandHandler<CreateTransportSheetCommand, Guid>
{
    private readonly TransportSheetCreator _creator;

    public CreateTransportSheetCommandHandler(TransportSheetCreator creator)
    {
        _creator = creator;
    }

    public async Task<Guid> Handle(CreateTransportSheetCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
