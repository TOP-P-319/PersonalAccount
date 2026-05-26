using PersonalAccount.Data.Entities;
using PersonalAccount.Models;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class GroupMapper : IMapper<GroupEntity, GroupModel>
{
    public GroupEntity ToEntity(GroupModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        ImageUrl = model.ImageUrl?.ToString(),
    };

    public GroupModel ToModel(GroupEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        ImageUrl = entity.ImageUrl?.ToUri(),
    };
}