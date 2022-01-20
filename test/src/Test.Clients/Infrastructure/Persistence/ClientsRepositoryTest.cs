using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Clients.Domain;
using Rusell.Test.Clients.Domain;
using Xunit;

namespace Rusell.Test.Clients.Infrastructure.Persistence;

public class ClientsRepositoryTest : ClientsContextInfrastructureTestCase
{
    private IClientsRepository Repository => GetService<IClientsRepository>();

    [Fact]
    public async Task Save_Should_Save_A_Client()
    {
        var client = ClientMother.Random();

        await Repository.Save(client);
    }

    [Fact]
    public async Task SearchAll_Should_Return_All_Clients()
    {
        var client = ClientMother.Random();
        await Repository.Save(client);

        var clients = await Repository.SearchAll();

        clients.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Find_Should_Return_A_Client()
    {
        var client = ClientMother.Random();
        await Repository.Save(client);

        var foundClient = await Repository.Find(client.Id);

        foundClient.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var foundClient = await Repository.Find(Guid.NewGuid().ToString());

        foundClient.Should().BeNull();
    }

    [Fact]
    public async Task Any_Should_Return_True()
    {
        var client = ClientMother.Random();
        await Repository.Save(client);

        var exists = await Repository.Any(x => x.Id == client.Id);

        exists.Should().BeTrue();
    }
}
