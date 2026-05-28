namespace PersonalAccount.Models;

public class ProfileModel : Model
{
    public int AccountId { get; set; }
    
    public string FullName { get; set; } = string.Empty;
    public Uri? PhotoUrl { get; set; }
}