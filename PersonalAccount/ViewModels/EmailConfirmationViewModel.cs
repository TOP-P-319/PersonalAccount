namespace PersonalAccount.ViewModels;

public class EmailConfirmationViewModel : ViewModel
{
    public int AccountId { get; set; }
    public string Token { get; set; } = string.Empty;
}