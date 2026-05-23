using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using PersonalAccount.Models.Student;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Account;

public class StudentAuthService(IStudentRepo<StudentAuthModel> students, IPasswordHasher<StudentAuthModel> hasher)
    : IStudentAuthService
{
    public async Task<StudentModel?> ValidateStudentAsync(string email, string password)
    {
        var student = await students.GetByEmailAsync(email);
        if (student is null) return null;

        var result = hasher.VerifyHashedPassword(student, student.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed) return null;

        return student.Clone() as StudentModel;
    }

    public async Task SignInAsync(HttpContext ctx, StudentModel student)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, student.Id.ToString()),
            new(ClaimTypes.Email, student.Email),
            new(ClaimTypes.Name, student.FullName),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    public async Task SignOutAsync(HttpContext ctx) => await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}