using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repository;

public class StudentRepo<T>(AppDbContext ctx, IMapper<StudentProfileEntity, T> mapper) : IStudentRepo<T> where T : StudentProfileModel
{
    private DbSet<StudentProfileEntity> Students => ctx.StudentProfiles;

    public async Task<T?> GetByEmailAsync(string email)
    {
        var entity = await Students
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Email == email);
        
        return entity == null ? null : mapper.ToModel(entity);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await Students.FindAsync(id);
        return entity == null ? null : mapper.ToModel(entity);
    }
}