using PersonalAccount.Data.Entities;
using PersonalAccount.Models;

namespace PersonalAccount.Mappers;

public interface IMapper<TEntity, TModel>
    where TEntity : Entity, new()
    where TModel : Model, new()
{
    TEntity ToEntity(TModel model);
    TModel ToModel(TEntity entity);
}