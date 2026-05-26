using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Account;

public class AccountService(IAccountRepo accountRepo, IPasswordHasher<AccountModel> hasher)
    : IAccountService
{
    public async Task<AccountModel?> ValidateCredentialsAsync(string email, string password)
    {
        var account = await accountRepo.GetByEmailAsync(email);
        if (account is null) return null;

        var result = hasher.VerifyHashedPassword(account, account.PasswordHash, password);
        return result == PasswordVerificationResult.Failed ? null : account;
    }

    public async Task SignInAsync(HttpContext ctx, AccountModel account)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Email, account.Email),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    public async Task SignOutAsync(HttpContext ctx) => await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}