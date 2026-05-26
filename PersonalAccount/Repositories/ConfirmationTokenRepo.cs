using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class ConfirmationTokenRepo(
    AppDbContext ctx,
    IMapper<ConfirmationTokenEntity, ConfirmationTokenModel> mapper
) : IConfirmationTokenRepo
{
    private DbSet<ConfirmationTokenEntity> ConfirmationTokens => ctx.ConfirmationTokens;

    public async Task AddAsync(ConfirmationTokenModel model)
    {
        await ConfirmationTokens.AddAsync(mapper.ToEntity(model));
        await ctx.SaveChangesAsync();
    }

    public async Task<List<ConfirmationTokenModel>> GetAllByAccountId(int accountId) =>
        await ConfirmationTokens
            .AsNoTracking()
            .Where(entity => entity.AccountId == accountId)
            .Select(entity => mapper.ToModel(entity))
            .ToListAsync();

    public async Task UpdateConfirmedAtAsync(int id, DateTime confirmedAt)
    {
        var entity = await ConfirmationTokens.FindAsync(id) ?? throw new KeyNotFoundException();
        entity.ConfirmedAt = confirmedAt;
        await ctx.SaveChangesAsync();
    }
}