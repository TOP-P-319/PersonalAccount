using PersonalAccount.Models;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Profile;

public class StudentProfileService(IStudentRepo<StudentProfileModel> students) : IStudentProfileService
{
    public async Task<StudentProfileModel?> GetByIdAsync(int id) => await students.GetByIdAsync(id);
}