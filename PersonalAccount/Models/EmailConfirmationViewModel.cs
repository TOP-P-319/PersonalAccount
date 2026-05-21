namespace PersonalAccount.Models;

public class EmailConfirmationViewModel
{
    public int StudentId { get; set; }
    public string Token { get; set; } = string.Empty;
}