using PersonalAccount.Models;

namespace PersonalAccount.Services.Account;

public interface IStudentAuthService
{
    Task<StudentProfileModel?> ValidateStudentAsync(string email, string password);
    Task SignInAsync(HttpContext ctx, StudentProfileModel studentProfile);
    Task SignOutAsync(HttpContext ctx);
}