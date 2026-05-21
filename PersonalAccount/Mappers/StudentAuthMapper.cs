using PersonalAccount.Data.Entities;
using PersonalAccount.Models.Student;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentAuthMapper : IMapper<StudentEntity, StudentAuthModel>
{
    public StudentEntity ToEntity(StudentAuthModel model) => new()
    {
        Id = model.Id,
        Email = model.Email,
        PasswordHash = model.PasswordHash,
        FullName = model.FullName,
        PhotoUrl = model.PhotoUrl?.ToString(),
        GroupName =  model.GroupName
    };

    public StudentAuthModel ToModel(StudentEntity entity) => new()
    {
        Id = entity.Id,
        Email = entity.Email,
        PasswordHash = entity.PasswordHash,
        FullName = entity.FullName,
        PhotoUrl = entity.PhotoUrl?.ToUri(),
        GroupName =  entity.GroupName
    };
}