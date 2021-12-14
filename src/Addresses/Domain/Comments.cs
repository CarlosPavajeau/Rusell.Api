using ValueOf;

namespace Rusell.Addresses.Domain;

public class Comments : ValueOf<string, Comments>
{
    public static implicit operator string(Comments comments) => comments.Value;
    public static implicit operator Comments(string comments) => From(comments);
}