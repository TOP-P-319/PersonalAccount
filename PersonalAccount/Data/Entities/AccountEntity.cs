using PersonalAccount.Types;

namespace PersonalAccount.Data.Entities;

public class AccountEntity :  Entity
{
    public StudentProfileEntity? StudentProfile { get; set; }
    public List<ConfirmationTokenEntity> ConfirmationTokens { get; set; } = [];

    public AccountRoles Role { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}