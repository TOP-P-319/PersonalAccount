using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Cabinet;

public class StudentCabinetService(IStudentProfileRepo studentProfileRepo, IGroupRepo groupRepo)
    : IStudentCabinetService
{
    public async Task<StudentProfileModel?> GetProfileAsync(int accountId) =>
        await studentProfileRepo.GetByAccountIdAsync(accountId);

    public async Task<GroupModel?> GetGroupAsync(int groupId) =>
        await groupRepo.GetByIdAsync(groupId);
}