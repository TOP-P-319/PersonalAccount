using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using PersonalAccount.Models;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Account;

public class StudentAuthService(IStudentRepo<StudentAuthModel> students, IPasswordHasher<StudentAuthModel> hasher)
    : IStudentAuthService
{
    public async Task<StudentProfileModel?> ValidateStudentAsync(string email, string password)
    {
        var student = await students.GetByEmailAsync(email);
        if (student is null) return null;

        var result = hasher.VerifyHashedPassword(student, student.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed) return null;

        return student.Clone() as StudentProfileModel;
    }

    public async Task SignInAsync(HttpContext ctx, StudentProfileModel studentProfile)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, studentProfile.ProfileId.ToString()),
            new(ClaimTypes.Email, studentProfile.Email),
            new(ClaimTypes.Name, studentProfile.FullName),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    public async Task SignOutAsync(HttpContext ctx) => await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}