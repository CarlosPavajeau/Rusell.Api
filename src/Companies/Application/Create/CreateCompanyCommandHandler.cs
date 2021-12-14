using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Companies.Application.Create;

public class CreateCompanyCommandHandler : CommandHandler<CreateCompanyCommand>
{
  private readonly CompanyCreator _creator;

  public CreateCompanyCommandHandler(CompanyCreator creator)
  {
    _creator = creator;
  }

  protected override async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
  {
    await _creator.Create(request);
  }
}