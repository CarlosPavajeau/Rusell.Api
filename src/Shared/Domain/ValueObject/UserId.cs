using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class UserId : ValueOf<string, UserId>
{
    public static implicit operator string(UserId userId) => userId.Value;
    public static implicit operator UserId(string userId) => From(userId);
}
