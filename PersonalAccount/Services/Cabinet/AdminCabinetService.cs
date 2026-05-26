using PersonalAccount.Models;
using PersonalAccount.Repositories;
using PersonalAccount.Types;

namespace PersonalAccount.Services.Cabinet;

public class AdminCabinetService(
    IAccountRepo accountRepo,
    IStudentProfileRepo studentProfileRepo,
    IGroupRepo groupRepo
) : IAdminCabinetService
{
    public async Task<List<AccountModel>> GetAllStudentAccountsAsync() =>
        await accountRepo.GetAllByRole(AccountRoles.Student);

    public async Task<List<StudentProfileModel>> GetAllStudentProfilesAsync() => 
        await studentProfileRepo.GetAllAsync();

    public async Task<List<GroupModel>> GetAllGroupsAsync() => await groupRepo.GetAllAsync();
}