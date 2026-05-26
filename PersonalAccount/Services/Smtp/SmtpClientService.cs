using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace PersonalAccount.Services.Smtp;

public class SmtpClientService(IOptions<SmtpClientSettings> options) : ISmtpClientService
{
    private readonly SmtpClientSettings _clientSettings = options.Value;

    public async Task SendEmailAsync(string to, string subject, string body) =>
        await SendMessageAsync(CreateEmailMessage(to, subject, body));

    private async Task SendMessageAsync(MimeMessage message)
    {
        using var client = new SmtpClient();
        client.Timeout = _clientSettings.Timeout;

        await client.ConnectAsync(_clientSettings.Host, _clientSettings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_clientSettings.Username, _clientSettings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    private MimeMessage CreateEmailMessage(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_clientSettings.FromName, _clientSettings.FromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new BodyBuilder
        {
            HtmlBody = body,
        }.ToMessageBody();

        return message;
    }
}