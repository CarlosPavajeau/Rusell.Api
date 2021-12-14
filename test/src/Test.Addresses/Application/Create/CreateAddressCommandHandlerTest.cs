using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rusell.Addresses.Application.Create;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Test.Addresses.Application.Create;

public class CreateAddressCommandHandlerTest : AddressesUnitTestCase
{
    private readonly IRequestHandler<CreateAddressCommand, Unit> _handler;

    public CreateAddressCommandHandlerTest()
    {
        _handler = new CreateAddressCommandHandler(new AddressCreator(Repository.Object));
    }

    [Fact]
    public async Task Create_ShouldCreateAnAddress()
    {
        var command = new CreateAddressCommand(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random());

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}