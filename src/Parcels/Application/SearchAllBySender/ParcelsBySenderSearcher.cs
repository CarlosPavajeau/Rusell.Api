using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Application.SearchAllBySender;

public class ParcelsBySenderSearcher
{
    private readonly IParcelsRepository _repository;

    public ParcelsBySenderSearcher(IParcelsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Parcel>> SearchAllBySender(ClientId senderId)
    {
        return await _repository.SearchAll(x => x.SenderId == senderId);
    }
}
