using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using PersonalAccount.Models;
using PersonalAccount.Repositories;
using PersonalAccount.Types;

namespace PersonalAccount.Services.Cabinet;

public class AdminCabinetService(
    IAccountRepo accountRepo,
    IStudentProfileRepo studentProfileRepo,
    IGroupRepo groupRepo,
    IPasswordHasher<AccountModel> hasher
) : IAdminCabinetService
{
    public async Task<List<AccountModel>> GetAllStudentAccountsAsync() =>
        await accountRepo.GetAllByRoleAsync(AccountRoles.Student);

    public async Task<List<StudentProfileModel>> GetAllStudentProfilesAsync() =>
        await studentProfileRepo.GetAllAsync();

    public async Task<List<GroupModel>> GetAllGroupsAsync() => await groupRepo.GetAllAsync();

    public async Task<bool> CheckEmailUniqueAsync(string email)
    {
        var account = await accountRepo.GetByEmailAsync(email);
        return account == null;
    }

    public async Task<string> RegisterStudentAccountWithGeneratedPasswordAsync(string email)
    {
        var password = RandomNumberGenerator.GetHexString(12);
        var account = new AccountModel
        {
            Email = email,
            Role = AccountRoles.Student,
        };
        account.PasswordHash = hasher.HashPassword(account, password);
        await accountRepo.AddAsync(account);
        return password;
    }

    public async Task RegisterStudentProfileForEmailAsync(string email, string fullName)
    {
        var account = await accountRepo.GetByEmailAsync(email);
        if (account == null) throw new KeyNotFoundException($"No account with email {email} found.");

        var studentProfile = new StudentProfileModel
        {
            FullName = fullName,
            AccountId = account.Id,
        };
        await studentProfileRepo.AddAsync(studentProfile);
    }
}