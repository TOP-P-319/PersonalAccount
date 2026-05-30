using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Cabinet;

public class TeacherCabinetService(
    ITeacherProfileRepo teacherProfileRepo,
    ITeacherGroupDisciplineRepo teacherGroupDisciplineRepo,
    IDisciplineRepo disciplineRepo,
    IGroupRepo groupRepo
)
    : ITeacherCabinetService
{
    public async Task<TeacherProfileModel?> GetProfileAsync(int accountId) =>
        await teacherProfileRepo.GetByAccountIdAsync(accountId);

    public async Task<Dictionary<DisciplineModel, List<GroupModel>>> GetGroupsByDisciplineAsync(
        int accountId)
    {
        var teacherGroupDisciplines = await teacherGroupDisciplineRepo.GetAllByTeacherAccountIdAsync(accountId);

        var groupsByDisciplines = new Dictionary<DisciplineModel, List<GroupModel>>();
        foreach (var teacherGroupDiscipline in teacherGroupDisciplines)
        {
            var discipline = await disciplineRepo.GetByIdAsync(teacherGroupDiscipline.DisciplineId);
            var group = await groupRepo.GetByIdAsync(teacherGroupDiscipline.GroupId);
            if (discipline == null || group == null) throw new KeyNotFoundException();

            if (!groupsByDisciplines.TryGetValue(discipline, out var groups))
                groupsByDisciplines[discipline] = [group];
            else
                groups.Add(group);
        }

        return groupsByDisciplines;
    }
}