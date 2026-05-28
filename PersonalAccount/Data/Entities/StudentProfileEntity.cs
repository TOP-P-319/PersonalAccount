namespace PersonalAccount.Data.Entities;

public class StudentProfileEntity : Entity
{
    public int AccountId { get; set; }
    public AccountEntity? Account { get; set; }

    public int? GroupId { get; set; }
    public GroupEntity? Group { get; set; }

    public string FullName { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
}