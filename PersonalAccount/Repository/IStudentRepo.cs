using PersonalAccount.Models.Student;

namespace PersonalAccount.Repository;

public interface IStudentRepo<T> where T : StudentModel
{
    Task<T?> GetByEmailAsync(string email);
}