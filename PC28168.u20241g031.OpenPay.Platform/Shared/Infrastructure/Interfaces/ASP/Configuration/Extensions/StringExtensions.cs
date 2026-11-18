using System.Text.RegularExpressions;

namespace PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
/// String extensions for converting route names to kebab-case.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public static partial class StringExtensions
{
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return KebabCaseRegex().Replace(text, "-$1")
            .Trim()
            .ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}