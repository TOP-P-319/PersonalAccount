using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class SubjectMapper : Mapper<SubjectEntity, SubjectModel>
{
    public override SubjectEntity ToEntity(SubjectModel model)
    {
        var entity = base.ToEntity(model);
        entity.Name = model.Name;
        return entity;
    }

    public override SubjectModel ToModel(SubjectEntity entity)
    {
        var model = base.ToModel(entity);
        model.Name = entity.Name;
        return model;
    }
}