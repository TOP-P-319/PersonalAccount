using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PersonalAccount.Constants;
using PersonalAccount.Models;
using PersonalAccount.Repositories;
using PersonalAccount.Types;

namespace PersonalAccount.Services.Bootstrap;

public class DbBootstrapService(
    IAccountRepo accountRepo,
    IGroupRepo groupRepo,
    IPasswordHasher<AccountModel> hasher,
    IOptions<DbBootstrapSettings> options)
{
    private readonly DbBootstrapSettings _settings = options.Value;

    public async Task SeedAsync() => await Task.WhenAll(SeedAccountAsync(), SeedNoGroupAsync());

    private async Task SeedAccountAsync()
    {
        var hasStudents = await accountRepo.AnyAsync();
        if (hasStudents) return;

        var account = new AccountModel
        {
            Email = _settings.Email,
            Role = AccountRoles.Admin
        };
        account.PasswordHash = hasher.HashPassword(account, _settings.Password);
        await accountRepo.AddAsync(account);
    }

    private async Task SeedNoGroupAsync()
    {
        var noGroup = await groupRepo.GetByIdAsync(GroupConstants.NoGroup.Id);
        if (noGroup != null) return;

        var group = new GroupModel
        {
            Id = GroupConstants.NoGroup.Id,
            Name = GroupConstants.NoGroup.Name,
            Description = GroupConstants.NoGroup.Description,
        };

        await groupRepo.AddAsync(group);
    }
}