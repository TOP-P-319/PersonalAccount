namespace PersonalAccount.Services.Smtp;

public interface ISmtpClientService
{
    Task SendEmailAsync(string to, string discipline, string body);
}