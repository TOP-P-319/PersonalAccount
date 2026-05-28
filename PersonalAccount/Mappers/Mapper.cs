using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public abstract class Mapper<TEntity, TModel> : IMapper<TEntity, TModel>
    where TEntity : Entity, new()
    where TModel : Model, new()
{
    public virtual TEntity ToEntity(TModel model) => new()
    {
        Id = model.Id
    };

    public virtual TModel ToModel(TEntity entity) => new()
    {
        Id = entity.Id
    };
}