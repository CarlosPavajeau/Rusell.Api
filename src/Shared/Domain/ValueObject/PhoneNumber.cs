using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class PhoneNumber : ValueOf<string, PhoneNumber>
{
    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
    public static implicit operator PhoneNumber(string phoneNumber) => From(phoneNumber);
}
