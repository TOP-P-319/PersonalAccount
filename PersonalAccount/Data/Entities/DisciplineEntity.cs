namespace PersonalAccount.Data.Entities;

public class DisciplineEntity : Entity
{
    public List<TeacherGroupDisciplineEntity>  TeacherGroupDisciplines { get; set; } = [];
    
    public string Name { get; set; }
}