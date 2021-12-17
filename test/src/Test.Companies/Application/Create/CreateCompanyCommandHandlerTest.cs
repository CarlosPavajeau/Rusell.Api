using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Rusell.Companies.Application.Create;
using Rusell.Shared.Domain.Bus.Event;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Companies.Application.Create;

public class CreateCompanyCommandHandlerTest : CompaniesUnitTestCase
{
    private readonly IRequestHandler<CreateCompanyCommand, Unit> _handler;

    public CreateCompanyCommandHandlerTest()
    {
        _handler = new CreateCompanyCommandHandler(new CompanyCreator(Repository.Object, new Mock<IEventBus>().Object));
    }

    [Fact]
    public async Task Create_ShouldCreateACompany()
    {
        var command = new CreateCompanyCommand(WordMother.Random(), WordMother.Random(), WordMother.Random(),
            WordMother.Random());

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}
