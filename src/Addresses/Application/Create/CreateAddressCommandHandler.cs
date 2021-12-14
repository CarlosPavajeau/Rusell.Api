using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Addresses.Application.Create;

public class CreateAddressCommandHandler : CommandHandler<CreateAddressCommand>
{
  private readonly AddressCreator _creator;

  public CreateAddressCommandHandler(AddressCreator creator)
  {
    _creator = creator;
  }

  protected override async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
  {
    await _creator.Create(request);
  }
}