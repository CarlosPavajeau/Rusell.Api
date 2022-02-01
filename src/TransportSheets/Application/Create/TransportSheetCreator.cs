using Mapster;
using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Application.Create;

public class TransportSheetCreator
{
    private readonly ITransportSheetsRepository _repository;

    public TransportSheetCreator(ITransportSheetsRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransportSheetId> Create(CreateTransportSheetCommand command)
    {
        var transportSheet = command.Adapt<TransportSheet>();
        await _repository.Save(transportSheet);

        return transportSheet.Id;
    }
}
