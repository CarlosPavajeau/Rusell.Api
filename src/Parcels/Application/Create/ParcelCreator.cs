using Mapster;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Application.Create;

public class ParcelCreator
{
    private readonly IParcelsRepository _repository;

    public ParcelCreator(IParcelsRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateParcelCommand command)
    {
        var parcel = command.Adapt<Parcel>();
        await _repository.Save(parcel);
    }
}
