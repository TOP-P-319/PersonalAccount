namespace PersonalAccount.Models.Student;

public class StudentModel : ICloneable
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string Email { get; set; } =  string.Empty;
    public Uri? PhotoUrl  { get; set; }

    public object Clone() => new StudentModel
    {
        Id = Id,
        FullName = FullName,
        GroupName = GroupName,
        Email = Email,
        PhotoUrl = PhotoUrl
    };
}