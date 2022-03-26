using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rusell.Parcels.Application.Create;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Parcels.Application.Create;

public class CreateParcelCommandHandlerTest : ParcelsUnitTestCase
{
    private readonly IRequestHandler<CreateParcelCommand, Unit> _handler;

    public CreateParcelCommandHandlerTest()
    {
        _handler = new CreateParcelCommandHandler(new ParcelCreator(Repository.Object));
    }

    [Fact]
    public async Task Create_ShouldCreateAParcel()
    {
        var command = new CreateParcelCommand(
            WordMother.Random(),
            MotherCreator.Random().Decimal(1, 10000),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            Guid.NewGuid()
        );

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}
