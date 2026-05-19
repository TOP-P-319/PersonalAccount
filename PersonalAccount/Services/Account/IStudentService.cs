using PersonalAccount.Models.Student;

namespace PersonalAccount.Services.Account;

public interface IStudentService
{
    Task<StudentModel?> GetByIdAsync(int id);
}