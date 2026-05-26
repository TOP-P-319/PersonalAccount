namespace PersonalAccount.Repositories;

public interface IProfileRepo<TProfileModel>
{
    Task<TProfileModel?> GetByAccountIdAsync(int accountId);
    Task<List<TProfileModel>> GetAllAsync();
}