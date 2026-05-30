using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class TeacherGroupDisciplineMapper : Mapper<TeacherGroupDisciplineEntity, TeacherGroupDisciplineModel>
{
    public override TeacherGroupDisciplineEntity ToEntity(TeacherGroupDisciplineModel model)
    {
        var entity = base.ToEntity(model);
        entity.TeacherAccountId = model.TeacherAccountId;
        entity.GroupId = model.GroupId;
        entity.DisciplineId = model.DisciplineId;
        return entity;
    }

    public override TeacherGroupDisciplineModel ToModel(TeacherGroupDisciplineEntity entity)
    {
        var model = base.ToModel(entity);
        model.TeacherAccountId = entity.TeacherAccountId;
        model.GroupId = entity.GroupId;
        model.DisciplineId = entity.DisciplineId;
        return model;
    }
}