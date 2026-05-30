namespace PersonalAccount.Data.Entities;

public class GroupEntity : Entity
{
    public List<StudentProfileEntity> StudentProfiles { get; set; } = [];
    public List<TeacherGroupDisciplineEntity>  TeacherGroupSubjets { get; set; } = [];

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}