using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringForge;

/// <summary>
/// Helpful, chainable extensions for common string manipulation tasks.
/// </summary>
public static partial class StringExtensions
{
    public static bool IsBlank(this string? value) => string.IsNullOrWhiteSpace(value);

    public static string OrEmpty(this string? value) => value ?? string.Empty;

    public static string NormalizeWhitespace(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        return WhitespaceRegex().Replace(value.Trim(), " ");
    }

    public static string RemoveDiacritics(this string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        var normalized = value.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(normalized.Length);

        foreach (var character in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(character);
            }
        }

        return builder.ToString().Normalize(NormalizationForm.FormC);
    }

    public static string OnlyDigits(this string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        var builder = new StringBuilder(value.Length);

        foreach (var character in value)
        {
            if (char.IsDigit(character))
            {
                builder.Append(character);
            }
        }

        return builder.ToString();
    }

    public static string Truncate(this string? value, int maxLength, string suffix = "...")
    {
        ArgumentOutOfRangeException.ThrowIfNegative(maxLength);
        ArgumentNullException.ThrowIfNull(suffix);

        if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
        {
            return value ?? string.Empty;
        }

        if (maxLength <= suffix.Length)
        {
            return suffix[..maxLength];
        }

        return string.Concat(value.AsSpan(0, maxLength - suffix.Length), suffix);
    }

    public static string Left(this string? value, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(length);

        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return value.Length <= length ? value : value[..length];
    }

    public static string Right(this string? value, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(length);

        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return value.Length <= length ? value : value[^length..];
    }

    public static string EnsureStartsWith(
        this string? value,
        string prefix,
        StringComparison comparison = StringComparison.Ordinal)
    {
        ArgumentNullException.ThrowIfNull(prefix);

        var text = value ?? string.Empty;
        return text.StartsWith(prefix, comparison) ? text : prefix + text;
    }

    public static string EnsureEndsWith(
        this string? value,
        string suffix,
        StringComparison comparison = StringComparison.Ordinal)
    {
        ArgumentNullException.ThrowIfNull(suffix);

        var text = value ?? string.Empty;
        return text.EndsWith(suffix, comparison) ? text : text + suffix;
    }

    public static string ReplaceMany(
        this string? value,
        IReadOnlyDictionary<string, string> replacements,
        StringComparison comparison = StringComparison.Ordinal)
    {
        ArgumentNullException.ThrowIfNull(replacements);

        var result = value ?? string.Empty;

        foreach (var replacement in replacements)
        {
            result = result.Replace(replacement.Key, replacement.Value, comparison);
        }

        return result;
    }

    public static bool ContainsAny(
        this string? value,
        IEnumerable<string> candidates,
        StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        ArgumentNullException.ThrowIfNull(candidates);

        return !string.IsNullOrEmpty(value)
            && candidates.Any(candidate => !string.IsNullOrEmpty(candidate) && value.Contains(candidate, comparison));
    }

    public static bool ContainsAll(
        this string? value,
        IEnumerable<string> candidates,
        StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        ArgumentNullException.ThrowIfNull(candidates);

        return !string.IsNullOrEmpty(value)
            && candidates
                .Where(candidate => !string.IsNullOrEmpty(candidate))
                .All(candidate => value.Contains(candidate, comparison));
    }

    public static string Between(
        this string? value,
        string start,
        string end,
        StringComparison comparison = StringComparison.Ordinal)
    {
        ArgumentNullException.ThrowIfNull(start);
        ArgumentNullException.ThrowIfNull(end);

        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        var startIndex = value.IndexOf(start, comparison);
        if (startIndex < 0)
        {
            return string.Empty;
        }

        startIndex += start.Length;
        var endIndex = value.IndexOf(end, startIndex, comparison);

        return endIndex < 0 ? string.Empty : value[startIndex..endIndex];
    }

    public static string ToSlug(this string? value, char separator = '-')
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        var normalized = value.RemoveDiacritics().ToLowerInvariant();
        var builder = new StringBuilder(normalized.Length);
        var previousWasSeparator = false;

        foreach (var character in normalized)
        {
            if (char.IsLetterOrDigit(character))
            {
                builder.Append(character);
                previousWasSeparator = false;
                continue;
            }

            if (!previousWasSeparator)
            {
                builder.Append(separator);
                previousWasSeparator = true;
            }
        }

        return builder.ToString().Trim(separator);
    }

    public static string ToSnakeCase(this string? value) => value.ToWords().ToDelimitedCase('_');

    public static string ToKebabCase(this string? value) => value.ToWords().ToDelimitedCase('-');

    public static string ToPascalCase(this string? value) => string.Concat(value.ToWords().Select(CapitalizeInvariant));

    public static string ToCamelCase(this string? value)
    {
        var pascal = value.ToPascalCase();
        return pascal.Length == 0 ? pascal : char.ToLowerInvariant(pascal[0]) + pascal[1..];
    }

    public static string ToTitleCase(this string? value, CultureInfo? culture = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        culture ??= CultureInfo.CurrentCulture;
        return culture.TextInfo.ToTitleCase(value.NormalizeWhitespace().ToLower(culture));
    }

    public static string Initials(this string? value, int maxLetters = 2)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxLetters);

        return string.Concat(value.ToWords()
            .Take(maxLetters)
            .Select(word => char.ToUpperInvariant(word[0])));
    }

    public static int CountOccurrences(
        this string? value,
        string search,
        StringComparison comparison = StringComparison.Ordinal)
    {
        ArgumentException.ThrowIfNullOrEmpty(search);

        if (string.IsNullOrEmpty(value))
        {
            return 0;
        }

        var count = 0;
        var index = 0;

        while ((index = value.IndexOf(search, index, comparison)) >= 0)
        {
            count++;
            index += search.Length;
        }

        return count;
    }

    public static bool IsPalindrome(this string? value, bool ignoreCase = true, bool ignoreNonLettersAndDigits = true)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        var cleaned = ignoreNonLettersAndDigits
            ? new string(value.Where(char.IsLetterOrDigit).ToArray())
            : value;

        if (ignoreCase)
        {
            cleaned = cleaned.ToLowerInvariant();
        }

        return cleaned.SequenceEqual(cleaned.Reverse());
    }

    public static IReadOnlyList<string> Words(this string? value) => value.ToWords();

    private static IReadOnlyList<string> ToWords(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return [];
        }

        var normalized = value.RemoveDiacritics();
        normalized = WordBoundaryRegex().Replace(normalized, "$1 $2");

        return NonWordRegex()
            .Split(normalized)
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .Select(word => word.Trim().ToLowerInvariant())
            .ToArray();
    }

    private static string ToDelimitedCase(this IReadOnlyList<string> words, char separator) => string.Join(separator, words);

    private static string CapitalizeInvariant(string word)
    {
        return word.Length == 0 ? word : char.ToUpperInvariant(word[0]) + word[1..];
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex();

    [GeneratedRegex(@"([a-z0-9])([A-Z])")]
    private static partial Regex WordBoundaryRegex();

    [GeneratedRegex(@"[^A-Za-z0-9]+")]
    private static partial Regex NonWordRegex();
}
