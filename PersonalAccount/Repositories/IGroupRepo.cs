using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public interface IGroupRepo
{
    Task<List<GroupModel>> GetAllAsync();
    Task<GroupModel?> GetByIdAsync(int groupId);
}