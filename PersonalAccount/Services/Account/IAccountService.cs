using PersonalAccount.Models;

namespace PersonalAccount.Services.Account;

public interface IAccountService
{
    Task<AccountModel?> ValidateCredentialsAsync(string email, string password);
    Task SignInAsync(HttpContext ctx, AccountModel account);
    Task SignOutAsync(HttpContext ctx);
}