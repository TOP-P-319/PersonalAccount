using PersonalAccount.Models.Student;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Account;

public class StudentService(IStudentRepo<StudentModel> students) : IStudentService
{
    public async Task<StudentModel?> GetByIdAsync(int id) => await students.GetByIdAsync(id);
}