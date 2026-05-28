using PersonalAccount.Constants;

namespace PersonalAccount.Models;

public class StudentProfileModel : Model
{
    public int AccountId { get; set; }
    public int GroupId { get; set; } = GroupConstants.NoGroup.Id;
    
    public string FullName { get; set; } = string.Empty;
    public Uri? PhotoUrl { get; set; }
}