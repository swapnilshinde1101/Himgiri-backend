using System.Threading;
using System.Threading.Tasks;

namespace Himgiri.Core.Interfaces.Services;

public interface IEmailService
{
    Task<bool> SendEmailAsync(
        string toEmail, 
        string subject, 
        string htmlBody, 
        byte[]? attachmentBytes = null, 
        string? attachmentFileName = null, 
        CancellationToken ct = default);

    Task<(bool Success, string Message)> SendTestEmailAsync(
        string toEmail,
        string? smtpHost = null,
        int? smtpPort = null,
        string? senderEmail = null,
        string? senderName = null,
        string? smtpPassword = null,
        bool? enableSsl = null,
        CancellationToken ct = default);
}
