using PersonalAccount.Models.Student;

namespace PersonalAccount.Services.Auth;

public interface IStudentAuthService
{
    Task<StudentModel?> ValidateStudentAsync(string email, string password);
    Task SignInAsync(HttpContext ctx, StudentModel student);
    Task SignOutAsync(HttpContext ctx);
}