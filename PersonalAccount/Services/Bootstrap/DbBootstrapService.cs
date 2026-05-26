using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Bootstrap;

public class DbBootstrapService(
    IAccountRepo accountRepo,
    IPasswordHasher<AccountModel> hasher,
    IOptions<DbBootstrapSettings> options)
{
    private readonly DbBootstrapSettings _settings = options.Value;

    public async Task SeedAsync()
    {
        var hasStudents = await accountRepo.AnyAsync();
        if (hasStudents) return;

        var account = new AccountModel
        {
            Email = _settings.Email,
        };
        account.PasswordHash = hasher.HashPassword(account, _settings.Password);
        await accountRepo.AddAsync(account);
    }
}