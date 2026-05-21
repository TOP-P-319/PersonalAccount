using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class ConfirmationTokenMapper : IMapper<ConfirmationTokenEntity, ConfirmationTokenModel>
{
    public ConfirmationTokenEntity ToEntity(ConfirmationTokenModel model) => new()
    {
        Id = model.Id,
        StudentId = model.StudentId,

        TokenHash = model.TokenHash,
        ConfirmedAt = model.ConfirmedAt,
        ExpiresAt = model.ExpiresAt
    };

    public ConfirmationTokenModel ToModel(ConfirmationTokenEntity entity) => new()
    {
        Id = entity.Id,
        StudentId = entity.StudentId,

        TokenHash = entity.TokenHash,
        ConfirmedAt = entity.ConfirmedAt,
        ExpiresAt = entity.ExpiresAt
    };
}