using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public class DisciplineMapper : Mapper<DisciplineEntity, DisciplineModel>
{
    public override DisciplineEntity ToEntity(DisciplineModel model)
    {
        var entity = base.ToEntity(model);
        entity.Name = model.Name;
        return entity;
    }

    public override DisciplineModel ToModel(DisciplineEntity entity)
    {
        var model = base.ToModel(entity);
        model.Name = entity.Name;
        return model;
    }
}