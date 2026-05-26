namespace PersonalAccount.Data.Entities;

public class StudentProfileEntity
{
    public int ProfileId { get; set; }
    public int AccountId { get; set; }
    public AccountEntity? Account { get; set; }
    
    public string FullName { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string? PhotoUrl  { get; set; }
}