using PersonalAccount.Data.Entities;
using PersonalAccount.Models.Student;
using PersonalAccount.Utils;

namespace PersonalAccount.Mappers;

public class StudentMapper : IMapper<StudentEntity, StudentModel>
{
    public StudentEntity ToEntity(StudentModel model) => new()
    {
        Id = model.Id,
        Email = model.Email,
        FullName = model.FullName,
        PhotoUrl = model.PhotoUrl?.ToString(),
        GroupName =  model.GroupName
    };

    public StudentModel ToModel(StudentEntity entity) => new()
    {
        Id = entity.Id,
        Email = entity.Email,
        FullName = entity.FullName,
        PhotoUrl = entity.PhotoUrl?.ToUri(),
        GroupName =  entity.GroupName
    };
}