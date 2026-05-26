using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class StudentProfileRepo(
    AppDbContext ctx,
    IMapper<StudentProfileEntity, StudentProfileModel> mapper
) : IStudentProfileRepo
{
    private DbSet<StudentProfileEntity> StudentProfiles => ctx.StudentProfiles;

    public async Task<StudentProfileModel?> GetByAccountIdAsync(int accountId)
    {
        var entity = await StudentProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.AccountId == accountId);
        return entity == null ? null : mapper.ToModel(entity);
    }

    public async Task<List<StudentProfileModel>> GetAllAsync() =>
        await StudentProfiles
            .AsNoTracking()
            .Select(entity => mapper.ToModel(entity))
            .ToListAsync();
}