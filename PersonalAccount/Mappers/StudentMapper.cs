using PersonalAccount.Data.Entities;
using PersonalAccount.Models;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentMapper : IMapper<StudentProfileEntity, StudentProfileModel>
{
    public StudentProfileEntity ToEntity(StudentProfileModel profileModel) => new()
    {
        ProfileId = profileModel.ProfileId,
        Email = profileModel.Email,
        FullName = profileModel.FullName,
        PhotoUrl = profileModel.PhotoUrl?.ToString(),
        GroupName =  profileModel.GroupName
    };

    public StudentProfileModel ToModel(StudentProfileEntity profileEntity) => new()
    {
        ProfileId = profileEntity.ProfileId,
        Email = profileEntity.Email,
        FullName = profileEntity.FullName,
        PhotoUrl = profileEntity.PhotoUrl?.ToUri(),
        GroupName =  profileEntity.GroupName
    };
}