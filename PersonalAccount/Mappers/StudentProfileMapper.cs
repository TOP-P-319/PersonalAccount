using PersonalAccount.Constants;
using PersonalAccount.Data.Entities;
using PersonalAccount.Models;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentProfileMapper : Mapper<StudentProfileEntity, StudentProfileModel>
{
    public override StudentProfileEntity ToEntity(StudentProfileModel model)
    {
        var entity = base.ToEntity(model);
        entity.AccountId = model.AccountId;
        entity.FullName = model.FullName;
        entity.PhotoUrl = model.PhotoUrl?.ToString();
        entity.GroupId = model.GroupId == GroupConstants.NoGroup.Id ? null : model.GroupId;
        return entity;
    }

    public override StudentProfileModel ToModel(StudentProfileEntity entity)
    {
        var model = base.ToModel(entity);
        model.AccountId = entity.AccountId;
        model.FullName = entity.FullName;
        model.PhotoUrl = entity.PhotoUrl?.ToUri();
        model.GroupId = entity.GroupId ?? GroupConstants.NoGroup.Id;
        return model;
    }
}