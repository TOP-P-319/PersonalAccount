using PersonalAccount.Data.Entities;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentAuthMapper : IMapper<StudentProfileEntity, StudentAuthModel>
{
    public StudentProfileEntity ToEntity(StudentAuthModel model) => new()
    {
        ProfileId = model.Id,
        Email = model.Email,
        PasswordHash = model.PasswordHash,
        FullName = model.FullName,
        PhotoUrl = model.PhotoUrl?.ToString(),
        GroupName =  model.GroupName
    };

    public StudentAuthModel ToModel(StudentProfileEntity profileEntity) => new()
    {
        Id = profileEntity.ProfileId,
        Email = profileEntity.Email,
        PasswordHash = profileEntity.PasswordHash,
        FullName = profileEntity.FullName,
        PhotoUrl = profileEntity.PhotoUrl?.ToUri(),
        GroupName =  profileEntity.GroupName
    };
}