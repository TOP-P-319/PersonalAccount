namespace PersonalAccount.Models;

public class StudentProfileModel
{
    public int ProfileId { get; set; }
    public int AccountId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public Uri? PhotoUrl  { get; set; }
}