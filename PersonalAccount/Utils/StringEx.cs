namespace PersonalAccount.Utils;

public static class StringEx
{
    public static Uri? ToUri(this string? str) => Uri.TryCreate(str, UriKind.Absolute, out var url) ? url : null;
}