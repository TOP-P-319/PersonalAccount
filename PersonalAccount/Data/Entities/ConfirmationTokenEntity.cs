namespace PersonalAccount.Data.Entities;

public class ConfirmationTokenEntity
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public StudentEntity? Student { get; set; }
    
    public string TokenHash { get; set; } =  string.Empty;
    public DateTime ExpiresAt { get; set; }
    public DateTime? ConfirmedAt { get; set; }
}