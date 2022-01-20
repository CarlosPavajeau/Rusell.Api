using System;
using Rusell.Clients.Domain;
using Rusell.Test.Shared.Domain;

namespace Rusell.Test.Clients.Domain;

public static class ClientMother
{
    public static Client Random() => Client.Create(
        Guid.NewGuid().ToString(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random(),
        WordMother.Random());
}
