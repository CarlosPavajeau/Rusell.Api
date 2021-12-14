using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Addresses.Application;
using Rusell.Addresses.Application.SearchAllByUser;
using Rusell.Addresses.Domain;
using Xunit;

namespace Test.Addresses.Application.SearchAllByUser;

public class SearchAllAddressesByUserQueryHandlerTest : AddressesUnitTestCase
{
    private readonly SearchAllAddressesByUserQueryHandler _handler;

    public SearchAllAddressesByUserQueryHandlerTest()
    {
        _handler = new SearchAllAddressesByUserQueryHandler(new AddressesByUserSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAllByUser("123")).ReturnsAsync(new List<Address>
        {
            new()
        });
    }

    [Fact]
    public async Task SearchAllByUser_Should_Return_Addresses()
    {
        var result = await _handler.Handle(new SearchAllAddressesByUserQuery("123"), CancellationToken.None);

        var addressResponses = result.ToList();
        addressResponses.Should().NotBeNull();
        addressResponses.Should().BeOfType<List<AddressResponse>>();
    }
}