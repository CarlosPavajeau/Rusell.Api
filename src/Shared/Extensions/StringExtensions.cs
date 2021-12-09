using System.Globalization;
using System.Text;

namespace Rusell.Shared.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Convert string to base64 string
    /// </summary>
    /// <param name="str">String to convert</param>
    /// <returns>A string represent in base64</returns>
    public static string ToBase64(this string str)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }

    /// <summary>
    /// Convert base64 string to string
    /// </summary>
    /// <param name="str">Base64 string</param>
    /// <returns>A normal string</returns>
    public static string FromBase64(this string str)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(str));
    }

    private static readonly Func<char, string> AddUnderscoreBeforeCapitalLetter =
        x => char.IsUpper(x) ? "_" + x : x.ToString(CultureInfo.InvariantCulture);

    public static string ToDatabaseFormat(this string value)
    {
        return string.Concat(value.Select(AddUnderscoreBeforeCapitalLetter))[1..].ToLowerInvariant();
    }
}
