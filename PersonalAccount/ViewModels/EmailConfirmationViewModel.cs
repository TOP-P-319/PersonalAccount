namespace PersonalAccount.ViewModels;

public class EmailConfirmationViewModel
{
    public int StudentId { get; set; }
    public string Token { get; set; } = string.Empty;
}