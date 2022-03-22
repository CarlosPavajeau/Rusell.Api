using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Addresses.Application.Find;
using Rusell.Addresses.Domain;
using Xunit;

namespace Rusell.Test.Addresses.Application.Find;

public class FindAddressQueryHandlerTest : AddressesUnitTestCase
{
    private readonly Guid _addressIdFound = Guid.NewGuid();
    private readonly Guid _addressIdNotFound = Guid.NewGuid();
    private readonly FindAddressQueryHandler _handler;

    public FindAddressQueryHandlerTest()
    {
        _handler = new FindAddressQueryHandler(new AddressFinder(Repository.Object));

        Repository.Setup(x => x.Find(_addressIdFound)).ReturnsAsync(new Address());
        Repository.Setup(x => x.Find(_addressIdNotFound)).ReturnsAsync((Address?) null);
    }

    [Fact]
    public async Task Find_Should_Return_Address()
    {
        var result = await _handler.Handle(new FindAddressQuery(_addressIdFound.ToString()), CancellationToken.None);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var result = await _handler.Handle(new FindAddressQuery(_addressIdNotFound.ToString()), CancellationToken.None);

        result.Should().BeNull();
    }
}
