using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public interface IProfileRepo<TProfileModel> : IRepo<TProfileModel>
    where TProfileModel : Model, new()
{
    Task<TProfileModel?> GetByAccountIdAsync(int accountId);
}