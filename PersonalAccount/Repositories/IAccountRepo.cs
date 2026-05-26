using PersonalAccount.Models;
using PersonalAccount.Types;

namespace PersonalAccount.Repositories;

public interface IAccountRepo
{
    Task<AccountModel?> GetByEmailAsync(string email);
    Task<List<AccountModel>> GetAllByRole(AccountRoles role);
    Task<bool> AnyAsync();
    Task AddAsync(AccountModel account);
}