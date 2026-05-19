using PersonalAccount.Models.Student;

namespace PersonalAccount.Services.Auth;

public interface IStudentAuthService
{
    Task<StudentModel?> ValidateStudentAsync(string email, string password);
}