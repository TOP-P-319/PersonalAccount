using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Profile;

public class StudentProfileService(IAccountRepo studentsProfile) : IStudentProfileService
{
    public async Task<StudentProfileModel?> GetByIdAsync(int id) => await studentsProfile.GetByIdAsync(id);
}