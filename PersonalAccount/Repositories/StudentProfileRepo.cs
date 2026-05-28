using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class StudentProfileRepo(
    AppDbContext ctx,
    IMapper<StudentProfileEntity, StudentProfileModel> mapper
) : Repo<StudentProfileEntity, StudentProfileModel>(ctx, mapper, c => c.StudentProfiles),
    IStudentProfileRepo
{
    public async Task<StudentProfileModel?> GetByAccountIdAsync(int accountId) =>
        await GetByAsync(entity => entity.AccountId == accountId);
}