using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class ConfirmationTokenMapper : IMapper<ConfirmationTokenEntity, ConfirmationTokenModel>
{
    public ConfirmationTokenEntity ToEntity(ConfirmationTokenModel model) => new()
    {
        Id = model.Id,
        AccountId = model.AccountId,

        TokenHash = model.TokenHash,
        ConfirmedAt = model.ConfirmedAt,
        ExpiresAt = model.ExpiresAt
    };

    public ConfirmationTokenModel ToModel(ConfirmationTokenEntity entity) => new()
    {
        Id = entity.Id,
        AccountId = entity.AccountId,

        TokenHash = entity.TokenHash,
        ConfirmedAt = entity.ConfirmedAt,
        ExpiresAt = entity.ExpiresAt
    };
}