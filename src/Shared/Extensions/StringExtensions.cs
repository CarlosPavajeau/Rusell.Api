using System.Globalization;
using System.Text;

namespace Rusell.Shared.Extensions;

public static class StringExtensions
{
    private static readonly Func<char, string> AddUnderscoreBeforeCapitalLetter =
        x => char.IsUpper(x) ? "_" + x : x.ToString(CultureInfo.InvariantCulture);

    /// <summary>
    ///     Convert string to base64 string
    /// </summary>
    /// <param name="str">String to convert</param>
    /// <returns>A string represent in base64</returns>
    public static string ToBase64(this string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

    /// <summary>
    ///     Convert base64 string to string
    /// </summary>
    /// <param name="str">Base64 string</param>
    /// <returns>A normal string</returns>
    public static string FromBase64(this string str) => Encoding.UTF8.GetString(Convert.FromBase64String(str));

    public static string ToDatabaseFormat(this string value) =>
        string.Concat(value.Select(AddUnderscoreBeforeCapitalLetter))[1..].ToLowerInvariant();

    public static string ToSnake(this string text)
    {
        return string.Concat(text.Select((x, i) =>
                i > 0 && char.IsUpper(x) ? "_" + x : x.ToString(CultureInfo.InvariantCulture)))
            .ToLowerInvariant();
    }

    public static string ToCamelFirstUpper(this string text)
    {
        var textInfo = new CultureInfo(CultureInfo.CurrentCulture.ToString(), false).TextInfo;
        return textInfo.ToTitleCase(text).Replace("_", string.Empty);
    }
}
