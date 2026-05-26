using System.Security.Cryptography;
using System.Text;
using PersonalAccount.Models;
using PersonalAccount.Repositories;

namespace PersonalAccount.Services.Tokens;

public class ConfirmationTokenService(IConfirmationTokenRepo confirmations) : IConfirmationTokenService
{
    public async Task<string> GenerateTokenAsync(int studentId)
    {
        var token = Guid.NewGuid().ToString();
        await confirmations.AddAsync(new ConfirmationTokenModel
        {
            AccountId = studentId,
            TokenHash = HashToken(token),
            ExpiresAt = DateTime.UtcNow.AddHours(12)
        });

        return token;
    }

    public async Task<bool> ValidateTokenAsync(int studentId, string token)
    {
        var tokens = await confirmations.GetAllByAccountId(studentId);
        var tokenHash = HashToken(token);
        var confirmation = tokens.FirstOrDefault(t =>
            t.TokenHash == tokenHash
            && DateTime.UtcNow < t.ExpiresAt
            && t.ConfirmedAt == null);

        if (confirmation == null) return false;

        try
        {
            await confirmations.UpdateConfirmedAtAsync(confirmation.Id, DateTime.UtcNow);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<bool> HasConfirmedTokenAsync(int studentId)
    {
        var tokens = await confirmations.GetAllByAccountId(studentId);
        return tokens.Any(t => t.ConfirmedAt != null);
    }

    private static string HashToken(string token) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
}