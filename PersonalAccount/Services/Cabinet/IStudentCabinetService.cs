using PersonalAccount.Models;

namespace PersonalAccount.Services.Cabinet;

public interface IStudentCabinetService
{
    Task<StudentProfileModel?> GetProfileAsync(int accountId);
    Task<GroupModel?> GetGroupAsync(int groupId);
}