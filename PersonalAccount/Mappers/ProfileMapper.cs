using PersonalAccount.Data.Entities;
using PersonalAccount.Models;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class ProfileMapper<TProfileEntity, TProfileModel> : Mapper<TProfileEntity, TProfileModel>
    where TProfileEntity : ProfileEntity, new()
    where TProfileModel : ProfileModel, new()
{
    public override TProfileEntity ToEntity(TProfileModel model)
    {
        var entity = base.ToEntity(model);
        entity.AccountId = model.AccountId;
        entity.FullName = model.FullName;
        entity.PhotoUrl = model.PhotoUrl?.ToString();
        return entity;
    }

    public override TProfileModel ToModel(TProfileEntity entity)
    {
        var model = base.ToModel(entity);
        model.AccountId = entity.AccountId;
        model.FullName = entity.FullName;
        model.PhotoUrl = entity.PhotoUrl?.ToUri();
        return model;
    }
}