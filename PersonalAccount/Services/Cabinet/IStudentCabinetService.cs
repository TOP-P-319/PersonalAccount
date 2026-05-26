using PersonalAccount.Models;

namespace PersonalAccount.Services.Cabinet;

public interface IStudentCabinetService
{
    Task<StudentProfileModel?> GetByAccountIdAsync(int accountId);
    Task<GroupModel?> GetGroupByIdAsync(int groupId);
}