using Microsoft.AspNetCore.Identity;
using PersonalAccount.Models.Student;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Auth;

public class StudentAuthService(IStudentRepo<StudentAuthModel> students, IPasswordHasher<StudentAuthModel> hasher) : IStudentAuthService
{
    public async Task<StudentModel?> ValidateStudentAsync(string email, string password)
    {
        var student = await students.GetByEmailAsync(email);
        if (student is null) return null;

        var result = hasher.VerifyHashedPassword(student, student.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed) return null;
        
        return student.Clone() as StudentModel;
    }
}