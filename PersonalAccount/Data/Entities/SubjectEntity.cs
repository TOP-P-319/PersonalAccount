namespace PersonalAccount.Data.Entities;

public class SubjectEntity : Entity
{
    public List<TeacherGroupSubjetEntity>  TeacherGroupSubjets { get; set; } = [];
    
    public string Name { get; set; }
}