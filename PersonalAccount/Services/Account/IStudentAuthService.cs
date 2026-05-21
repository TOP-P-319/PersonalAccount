using PersonalAccount.Models.Student;

namespace PersonalAccount.Services.Account;

public interface IStudentAuthService
{
    Task<StudentModel?> ValidateStudentAsync(string email, string password);
    Task SignInAsync(HttpContext ctx, StudentModel student);
    Task SignOutAsync(HttpContext ctx);
}