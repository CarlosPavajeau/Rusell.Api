using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Rusell.Addresses.Application.Create;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Addresses.Application.Create;

public class CreateAddressCommandHandlerTest : AddressesUnitTestCase
{
    private readonly IRequestHandler<CreateAddressCommand, Unit> _handler;

    public CreateAddressCommandHandlerTest()
    {
        _handler = new CreateAddressCommandHandler(new AddressCreator(Repository.Object, new Mock<IEventBus>().Object));
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
