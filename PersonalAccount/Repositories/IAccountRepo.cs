using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public interface IAccountRepo
{
    Task<AccountModel?> GetByEmailAsync(string email);
    Task<AccountModel?> GetByIdAsync(int id);
    Task<bool> AnyAsync();
    Task AddAsync(AccountModel account);
}