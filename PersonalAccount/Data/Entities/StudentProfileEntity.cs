namespace PersonalAccount.Data.Entities;

public class StudentProfileEntity : ProfileEntity
{
    public int? GroupId { get; set; }
    public GroupEntity? Group { get; set; }
}