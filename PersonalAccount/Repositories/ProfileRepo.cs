using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public abstract class ProfileRepo<TProfileEntity, TProfileModel>(
    AppDbContext ctx,
    IMapper<TProfileEntity, TProfileModel> mapper,
    Func<AppDbContext, DbSet<TProfileEntity>> tableSelector) :
    Repo<TProfileEntity, TProfileModel>(ctx, mapper, tableSelector),
    IProfileRepo<TProfileModel>
    where TProfileEntity : ProfileEntity, new()
    where TProfileModel : ProfileModel, new()
{
    public async Task<TProfileModel?> GetByAccountIdAsync(int accountId) =>
        await GetByAsync(entity => entity.AccountId == accountId);
}