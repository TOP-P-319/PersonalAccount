namespace PersonalAccount.Models;

public class TeacherGroupDisciplineModel : Model
{
    public int TeacherAccountId { get; set; }
    public int GroupId { get; set; }
    public int DisciplineId { get; set; }
    
    public override bool Equals(object? obj) =>
        obj is TeacherGroupDisciplineModel 
        && base.Equals(obj);
}