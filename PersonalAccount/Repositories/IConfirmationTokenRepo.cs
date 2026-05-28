using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public interface IConfirmationTokenRepo : IRepo<ConfirmationTokenModel>
{
    Task<List<ConfirmationTokenModel>> GetAllByAccountId(int accountId);
    Task UpdateConfirmedAtAsync(int id, DateTime confirmedAt);
}