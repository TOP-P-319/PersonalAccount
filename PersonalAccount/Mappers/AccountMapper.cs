using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class AccountMapper : Mapper<AccountEntity, AccountModel>
{
    public override AccountEntity ToEntity(AccountModel model)
    {
        var entity = base.ToEntity(model);
        entity.Email = model.Email;
        entity.PasswordHash = model.PasswordHash;
        entity.Role = model.Role;
        return entity;
    }

    public override AccountModel ToModel(AccountEntity entity)
    {
        var model = base.ToModel(entity);
        model.Email = entity.Email;
        model.PasswordHash = entity.PasswordHash;
        model.Role = entity.Role;
        return model;
    }
}