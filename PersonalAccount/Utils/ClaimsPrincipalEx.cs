using System.Security.Claims;
using PersonalAccount.Types;

namespace PersonalAccount.Utils;

public static class ClaimsPrincipalEx
{
    public static int? GetFieldAsNumber(this ClaimsPrincipal principal, string field) =>
        int.TryParse(principal.FindFirstValue(field), out var num) ? num : null;

    public static TEnum? GetFieldAsEnum<TEnum>(this ClaimsPrincipal principal, string field) where TEnum : struct =>
        Enum.TryParse<TEnum>(principal.FindFirstValue(field), out var e) ? e : null;

    public static int? GetId(this ClaimsPrincipal user) => user.GetFieldAsNumber(ClaimTypes.NameIdentifier);
    public static string? GetEmail(this ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.Email);

    public static AccountRoles? GetRole(this ClaimsPrincipal user) =>
        user.GetFieldAsEnum<AccountRoles>(ClaimTypes.Role);
}