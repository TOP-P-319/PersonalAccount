using PersonalAccount.Data.Entities;
using PersonalAccount.Models.Student;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentMapper : IMapper<StudentProfileEntity, StudentModel>
{
    public StudentProfileEntity ToEntity(StudentModel model) => new()
    {
        ProfileId = model.Id,
        Email = model.Email,
        FullName = model.FullName,
        PhotoUrl = model.PhotoUrl?.ToString(),
        GroupName =  model.GroupName
    };

    public StudentModel ToModel(StudentProfileEntity profileEntity) => new()
    {
        Id = profileEntity.ProfileId,
        Email = profileEntity.Email,
        FullName = profileEntity.FullName,
        PhotoUrl = profileEntity.PhotoUrl?.ToUri(),
        GroupName =  profileEntity.GroupName
    };
}