namespace PersonalAccount.Models;

public class ConfirmationTokenModel : Model
{
    public int AccountId { get; set; }
    
    public string TokenHash { get; set; } =  string.Empty;
    public DateTime ExpiresAt { get; set; }
    public DateTime? ConfirmedAt { get; set; }
}