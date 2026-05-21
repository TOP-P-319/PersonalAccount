using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace PersonalAccount.Services.Smtp;

public class SmtpClientService(IOptions<SmtpSettings> options) : ISmtpClientService
{
    private readonly SmtpSettings _settings = options.Value;

    public async Task SendEmailAsync(string to, string subject, string body) =>
        await SendMessageAsync(CreateEmailMessage(to, subject, body));

    private async Task SendMessageAsync(MimeMessage message)
    {
        using var client = new SmtpClient();
        client.Timeout = _settings.Timeout;

        await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_settings.Username, _settings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    private MimeMessage CreateEmailMessage(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new BodyBuilder
        {
            HtmlBody = body,
        }.ToMessageBody();

        return message;
    }
}