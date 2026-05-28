namespace PersonalAccount.Models;

public class TeacherGroupSubjectModel : Model
{
    public int TeacherAccountId { get; set; }
    public int GroupId { get; set; }
    public int SubjectId { get; set; }
}