using Mapster;
using Rusell.Clients.Application;
using Rusell.Clients.Domain;

namespace Rusell.Clients.Shared.Infrastructure.Mapping;

public class ClientToClientResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Client, ClientResponse>()
            .MapWith(s =>
                new ClientResponse(s.Id, $"{s.FirstName} {s.MiddleName} {s.FirstSurname} {s.SecondSurname}"));
    }
}
