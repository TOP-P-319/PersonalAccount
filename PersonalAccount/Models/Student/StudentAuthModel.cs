namespace PersonalAccount.Models.Student;

public class StudentAuthModel : StudentModel
{
    public string PasswordHash  { get; set; } = string.Empty;
}