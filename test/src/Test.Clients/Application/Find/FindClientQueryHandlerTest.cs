using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Clients.Application.Find;
using Rusell.Clients.Domain;
using Rusell.Test.Clients.Domain;
using Xunit;

namespace Rusell.Test.Clients.Application.Find;

public class FindClientQueryHandlerTest : ClientsUnitTestCase
{
    private readonly FindClientQueryHandler _handler;
    private readonly string _clientIdFound = Guid.NewGuid().ToString();
    private readonly string _clientIdNotFound = Guid.NewGuid().ToString();

    public FindClientQueryHandlerTest()
    {
        _handler = new FindClientQueryHandler(new ClientFinder(Repository.Object));

        Repository.Setup(x => x.Find(_clientIdFound)).ReturnsAsync(ClientMother.Random());
        Repository.Setup(x => x.Find(_clientIdNotFound)).ReturnsAsync((Client?) null);
    }

    [Fact]
    public async Task Find_Should_Return_A_Client()
    {
        var result = await _handler.Handle(new FindClientQuery(_clientIdFound), CancellationToken.None);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var result = await _handler.Handle(new FindClientQuery(_clientIdNotFound), CancellationToken.None);

        result.Should().BeNull();
    }
}
