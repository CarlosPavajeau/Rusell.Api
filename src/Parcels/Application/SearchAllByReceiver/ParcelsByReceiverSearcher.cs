using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Application.SearchAllByReceiver;

public class ParcelsByReceiverSearcher
{
    private readonly IParcelsRepository _repository;

    public ParcelsByReceiverSearcher(IParcelsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Parcel>> SearchAllByReceiver(ClientId receiverId)
    {
        return await _repository.SearchAll(x => x.ReceiverId == receiverId);
    }
}
