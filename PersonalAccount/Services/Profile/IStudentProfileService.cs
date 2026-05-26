using PersonalAccount.Models;

namespace PersonalAccount.Services.Profile;

public interface IStudentProfileService
{
    Task<StudentProfileModel?> GetByIdAsync(int id);
}