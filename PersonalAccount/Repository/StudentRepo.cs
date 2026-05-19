using PersonalAccount.Models.Student;

namespace PersonalAccount.Repository;

public class StudentRepo<T> : IStudentRepo<T> where T : StudentModel
{
    public async Task<T?> GetByEmailAsync(string email)
    {
        return null;
    }
}