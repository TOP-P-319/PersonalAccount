namespace PersonalAccount.ViewModels;

public class StudentProfileViewModel
{
    public string? PhotoUrl  { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    
    public string Email { get; set; } =  string.Empty;
    public bool IsEmailConfirmed { get; set; }
}