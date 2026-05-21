namespace PersonalAccount.Services.Tokens;

public interface IConfirmationTokenService
{
    Task<string> GenerateTokenAsync(int studentId);
    Task<bool> ValidateTokenAsync(int studentId, string token);
    Task<bool> HasConfirmedTokenAsync(int studentId);
}