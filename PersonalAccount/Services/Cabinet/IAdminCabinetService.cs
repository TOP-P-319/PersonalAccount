using PersonalAccount.Models;

namespace PersonalAccount.Services.Cabinet;

public interface IAdminCabinetService
{
    Task<List<AccountModel>> GetAllStudentAccounts();
    Task<List<StudentProfileModel>> GetAllStudentProfiles();
}