using PersonalAccount.Data.Entities;
using PersonalAccount.Models;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentProfileMapper : IMapper<StudentProfileEntity, StudentProfileModel>
{
    public StudentProfileEntity ToEntity(StudentProfileModel model) => new()
    {
        ProfileId = model.ProfileId,
        AccountId = model.AccountId,
        FullName = model.FullName,
        PhotoUrl = model.PhotoUrl?.ToString(),
        GroupName =  model.GroupName
    };

    public StudentProfileModel ToModel(StudentProfileEntity entity) => new()
    {
        ProfileId = entity.ProfileId,
        AccountId = entity.AccountId,
        FullName = entity.FullName,
        PhotoUrl = entity.PhotoUrl?.ToUri(),
        GroupName =  entity.GroupName
    };
}