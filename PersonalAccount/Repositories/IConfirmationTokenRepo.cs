using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public interface IConfirmationTokenRepo
{
    Task AddAsync(ConfirmationTokenModel model);
    Task<List<ConfirmationTokenModel>> GetAllByAccountId(int  accountId);
    Task UpdateConfirmedAtAsync(int id, DateTime confirmedAt);
}