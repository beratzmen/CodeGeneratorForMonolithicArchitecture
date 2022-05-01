namespace CodeGenerator.Extensions;

public static class StringExtensions
{
    public static string AddPrefixIf(this string text, string prefix, bool condition)
        => condition ? prefix + text : text;

    public static string AddSuffixIf(this string text, string suffix, bool condition)
        => condition ? text + suffix : text;

    public static string TrimFileContent(this string content)
        => content.Trim('\r', '\n', '\t', ' ');

    public static string PascalToCamelCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return
            value.Length == 1
                ? value.ToLower()
                : value[0].ToString().ToLower() + value[1..];
    }

    public static string PascalToSnakeCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return
            string
                .Concat(
                    value.Select(
                        (c, i) =>
                            i > 0 &&
                            char.IsUpper(c)
                                ? "_" + c
                                : c.ToString()))
                .ToLowerInvariant();
    }

    public static string PascalToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return
            string
                .Concat(
                    value.Select(
                        (c, i) =>
                            i > 0 &&
                            char.IsUpper(c)
                                ? "_" + c
                                : c.ToString()))
                .ToLowerInvariant();
    }

    public static string PascalToLowerWords(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return
            string
                .Concat(
                    value.Select(
                        (c, i) =>
                            i > 0 &&
                            char.IsUpper(c)
                                ? " " + c
                                : c.ToString()))
                .ToLowerInvariant();
    }
}