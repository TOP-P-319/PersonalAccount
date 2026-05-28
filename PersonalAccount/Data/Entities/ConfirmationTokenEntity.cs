namespace PersonalAccount.Data.Entities;

public class ConfirmationTokenEntity : Entity
{
    public int AccountId { get; set; }
    public AccountEntity? Account { get; set; }
    
    public string TokenHash { get; set; } =  string.Empty;
    public DateTime ExpiresAt { get; set; }
    public DateTime? ConfirmedAt { get; set; }
}