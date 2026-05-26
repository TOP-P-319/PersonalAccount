using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class AccountMapper : IMapper<AccountEntity, AccountModel>
{
    public AccountEntity ToEntity(AccountModel model) => new()
    {
       Id = model.Id,
       Email =  model.Email,
       PasswordHash = model.PasswordHash,
    };

    public AccountModel ToModel(AccountEntity entity) => new()
    {
        Id = entity.Id,
        Email =  entity.Email,
        PasswordHash = entity.PasswordHash,
    };
}