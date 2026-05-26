using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class AccountRepo(AppDbContext ctx, IMapper<AccountEntity, AccountModel> mapper) : IAccountRepo
{
    private DbSet<AccountEntity> Accounts => ctx.Accounts;

    public async Task<AccountModel?> GetByEmailAsync(string email)
    {
        var entity = await Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Email == email);

        return entity == null ? null : mapper.ToModel(entity);
    }

    public async Task<AccountModel?> GetByIdAsync(int id)
    {
        var entity = await Accounts.FindAsync(id);
        return entity == null ? null : mapper.ToModel(entity);
    }

    public async Task<bool> AnyAsync() =>
        await ctx.Accounts.AnyAsync();

    public async Task AddAsync(AccountModel account)
    {
        await ctx.Accounts.AddAsync(mapper.ToEntity(account));
        await ctx.SaveChangesAsync();
    }
}