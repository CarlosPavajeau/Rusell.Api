using ValueOf;

namespace Rusell.Routes.Addresses.Domain;

public class AddressId : ValueOf<Guid, AddressId>
{
    public static implicit operator Guid(AddressId addressId) => addressId.Value;
    public static implicit operator AddressId(Guid addressId) => From(addressId);
}
