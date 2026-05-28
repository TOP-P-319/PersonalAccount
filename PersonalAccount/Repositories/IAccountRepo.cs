using PersonalAccount.Models;
using PersonalAccount.Types;

namespace PersonalAccount.Repositories;

public interface IAccountRepo : IRepo<AccountModel>
{
    Task<AccountModel?> GetByEmailAsync(string email);
    Task<List<AccountModel>> GetAllByRoleAsync(AccountRoles role);
}