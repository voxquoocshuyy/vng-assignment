using Application.Common.Models;
using Infrastructure.Services.MailServices;
using MailKit.Net.Smtp;
using MimeKit;

namespace Application.Services.MailServices;

public class SmtpEmailService : ISmtpEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly SmtpClient _smtpClient;

    public SmtpEmailService(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings ?? throw new ArgumentNullException(nameof(emailSettings));
        _smtpClient = new SmtpClient();
    }
    
    public async Task SendEmailAsync(MailRequest request, CancellationToken cancellationToken = new CancellationToken())
    {
        var emailMessage = new MimeMessage
        {
            Sender = new MailboxAddress(_emailSettings.DisplayName, request.From ?? _emailSettings.From),
            Subject = request.Subject,
            Body = new BodyBuilder
            {
                HtmlBody = request.Body
            }.ToMessageBody()
        };
        if (request.ToAddresses.Any())
        {
            foreach (var toAddress in request.ToAddresses)
            {
                emailMessage.To.Add(MailboxAddress.Parse(toAddress));
            }
        }
        else
        {
            var toAddress = MailboxAddress.Parse(request.ToAddress);
            emailMessage.To.Add(toAddress);
        }

        try
        {
            await _smtpClient.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, _emailSettings.UseSsl,
                cancellationToken);
            await _smtpClient.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password, cancellationToken);
            await _smtpClient.SendAsync(emailMessage, cancellationToken);
            await _smtpClient.DisconnectAsync(true, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        finally
        {
            await _smtpClient.DisconnectAsync(true, cancellationToken);
            _smtpClient.Dispose();
        }
    }
}