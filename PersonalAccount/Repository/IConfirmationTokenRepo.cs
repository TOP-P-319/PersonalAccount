using PersonalAccount.Models;

namespace PersonalAccount.Repository;

public interface IConfirmationTokenRepo
{
    Task AddAsync(ConfirmationTokenModel model);
    Task<List<ConfirmationTokenModel>> GetAllByStudentId(int  studentId);
    Task UpdateConfirmedAtAsync(int id, DateTime confirmedAt);
}