using PersonalAccount.Models;

namespace PersonalAccount.Services.Cabinet;

public interface IAdminPanelService
{
    Task<List<AccountModel>> GetAllStudentAccountsAsync();
    Task<List<StudentProfileModel>> GetAllStudentProfilesAsync();
    Task<List<GroupModel>> GetAllGroupsAsync();
    Task<bool> CheckEmailUniqueAsync(string email);
    Task<string> RegisterStudentAccountWithGeneratedPasswordAsync(string email);
    Task RegisterStudentProfileForEmailAsync(string email, string fullName);
}