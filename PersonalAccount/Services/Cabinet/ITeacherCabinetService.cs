using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Cabinet;

public interface ITeacherCabinetService
{
    Task<TeacherProfileModel?> GetProfileAsync(int accountId);
    Task<Dictionary<DisciplineModel, List<GroupModel>>> GetGroupsByDisciplineAsync(int accountId);
}