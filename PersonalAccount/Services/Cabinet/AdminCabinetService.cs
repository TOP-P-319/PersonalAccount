using PersonalAccount.Models;
using PersonalAccount.Repositories;
using PersonalAccount.Types;

namespace PersonalAccount.Services.Cabinet;

public class AdminCabinetService(IAccountRepo accountRepo, IStudentProfileRepo studentProfileRepo)
    : IAdminCabinetService
{
    public async Task<List<AccountModel>> GetAllStudentAccounts() =>
        await accountRepo.GetAllByRole(AccountRoles.Student);

    public async Task<List<StudentProfileModel>> GetAllStudentProfiles() =>
        await studentProfileRepo.GetAllAsync();
}