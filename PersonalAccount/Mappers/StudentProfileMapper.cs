using PersonalAccount.Constants;
using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class StudentProfileMapper : ProfileMapper<StudentProfileEntity, StudentProfileModel>
{
    public override StudentProfileEntity ToEntity(StudentProfileModel model)
    {
        var entity = base.ToEntity(model);
        entity.GroupId = model.GroupId == GroupConstants.NoGroup.Id ? null : model.GroupId;
        return entity;
    }

    public override StudentProfileModel ToModel(StudentProfileEntity entity)
    {
        var model = base.ToModel(entity);
        model.GroupId = entity.GroupId ?? GroupConstants.NoGroup.Id;
        return model;
    }
}