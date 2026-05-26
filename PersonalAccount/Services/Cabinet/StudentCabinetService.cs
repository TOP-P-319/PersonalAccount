using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Cabinet;

public class StudentCabinetService(IStudentProfileRepo studentProfileRepo) : IStudentCabinetService
{
    public async Task<StudentProfileModel?> GetByAccountIdAsync(int accountId) =>
        await studentProfileRepo.GetByAccountIdAsync(accountId);
}