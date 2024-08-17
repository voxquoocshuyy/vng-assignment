using Application.Common.Models;

namespace Infrastructure.Services.MailServices;

public interface ISmtpEmailService
{
    Task SendEmailAsync(MailRequest mailRequest, CancellationToken cancellationToken = new CancellationToken());
}