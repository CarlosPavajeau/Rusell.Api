using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class Email : ValueOf<string, Email>
{
    public static implicit operator string(Email email) => email.Value;
    public static implicit operator Email(string email) => From(email);
}
