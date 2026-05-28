using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class GroupRepo(AppDbContext ctx, IMapper<GroupEntity, GroupModel> mapper) : IGroupRepo
{
    private DbSet<GroupEntity> Groups => ctx.Groups;

    public async Task<List<GroupModel>> GetAllAsync() =>
        await Groups
            .AsNoTracking()
            .Select(entity => mapper.ToModel(entity))
            .ToListAsync();

    public async Task<GroupModel?> GetByIdAsync(int groupId)
    {
        var entity = await Groups.FindAsync(groupId);
        return entity == null ? null : mapper.ToModel(entity);
    }

    public async Task AddAsync(GroupModel group)
    {
        await Groups.AddAsync(mapper.ToEntity(group));
        await ctx.SaveChangesAsync();
    }
}