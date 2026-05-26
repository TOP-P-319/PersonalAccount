using PersonalAccount.Models;

namespace PersonalAccount.Repository;

public interface IStudentRepo<T> where T : StudentProfileModel
{
    Task<T?> GetByEmailAsync(string email);
    Task<T?> GetByIdAsync(int id);
}