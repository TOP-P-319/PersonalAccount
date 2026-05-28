using PersonalAccount.Constants;
using PersonalAccount.Data.Entities;
using PersonalAccount.Models;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentProfileMapper : IMapper<StudentProfileEntity, StudentProfileModel>
{
    public StudentProfileEntity ToEntity(StudentProfileModel model) => new()
    {
        Id = model.Id,
        AccountId = model.AccountId,
        FullName = model.FullName,
        PhotoUrl = model.PhotoUrl?.ToString(),
        GroupId = model.GroupId == GroupConstants.NoGroup.Id ? null : model.GroupId,
    };

    public StudentProfileModel ToModel(StudentProfileEntity entity) => new()
    {
        Id = entity.Id,
        AccountId = entity.AccountId,
        FullName = entity.FullName,
        PhotoUrl = entity.PhotoUrl?.ToUri(),
        GroupId = entity.GroupId ?? GroupConstants.NoGroup.Id,
    };
}