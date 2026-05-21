using System.Security.Claims;

namespace PersonalAccount.Utils;

public static class ClaimsPrincipalEx
{
    public static int? GetFieldAsNumber(this ClaimsPrincipal principal, string field) => int.TryParse(principal.FindFirstValue(field), out var id) ? id : null;
    
    public static int? GetId(this ClaimsPrincipal user) => user.GetFieldAsNumber(ClaimTypes.NameIdentifier);
    public static string? GetEmail(this ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.Email);
    public static string? GetName(this ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.Name);
}