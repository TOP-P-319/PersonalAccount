namespace PersonalAccount.ViewModels;

public class EmailConfirmationViewModel
{
    public int AccountId { get; set; }
    public string Token { get; set; } = string.Empty;
}