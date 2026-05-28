using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class TeacherGroupSubjectMapper : Mapper<TeacherGroupSubjetEntity, TeacherGroupSubjectModel>
{
    public override TeacherGroupSubjetEntity ToEntity(TeacherGroupSubjectModel model)
    {
        var entity = base.ToEntity(model);
        entity.TeacherAccountId = model.TeacherAccountId;
        entity.GroupId = model.GroupId;
        entity.SubjectId = model.SubjectId;
        return entity;
    }

    public override TeacherGroupSubjectModel ToModel(TeacherGroupSubjetEntity entity)
    {
        var model = base.ToModel(entity);
        model.TeacherAccountId = entity.TeacherAccountId;
        model.GroupId = entity.GroupId;
        model.SubjectId = entity.SubjectId;
        return model;
    }
}