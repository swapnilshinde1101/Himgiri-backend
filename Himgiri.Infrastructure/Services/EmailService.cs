using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Infrastructure.Data;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Himgiri.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly HimgiriDbContext _db;
    private readonly IConfiguration _config;
    private readonly ILogger<EmailService> _logger;
    private readonly IDataProtector _protector;

    public EmailService(HimgiriDbContext db, IConfiguration config, ILogger<EmailService> logger, IDataProtectionProvider dataProtectionProvider)
    {
        _db = db;
        _config = config;
        _logger = logger;
        _protector = dataProtectionProvider.CreateProtector("Himgiri.EmailSettings.SmtpPassword");
    }

    private async Task<(string Host, int Port, string SenderEmail, string SenderName, string Password, bool EnableSsl, bool IsConfigured)> ResolveSettingsAsync(CancellationToken ct = default)
    {
        // 1. Try DB configuration first
        try
        {
            var dbConfig = await _db.EmailConfigurations.FirstOrDefaultAsync(c => !c.IsDeleted, ct);
            if (dbConfig != null && dbConfig.IsConfigured && !string.IsNullOrWhiteSpace(dbConfig.SmtpHost))
            {
                return (
                    dbConfig.SmtpHost,
                    dbConfig.SmtpPort,
                    dbConfig.SenderEmail,
                    dbConfig.SenderName,
                    DecryptPassword(dbConfig.SmtpPassword),
                    dbConfig.EnableSsl,
                    dbConfig.IsConfigured
                );
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load email configuration from database, falling back to appsettings.");
        }

        // 2. Fallback to appsettings.json
        var host = _config["Email:SmtpHost"] ?? "smtp.gmail.com";
        var portStr = _config["Email:SmtpPort"];
        var senderEmail = _config["Email:SenderEmail"] ?? "noreply@himgirigoods.com";
        var senderName = _config["Email:SenderName"] ?? "Himgiri Goods & Uniforms";
        var password = _config["Email:Password"] ?? string.Empty;
        var enableSsl = !bool.TryParse(_config["Email:EnableSsl"], out var ssl) || ssl;
        var port = int.TryParse(portStr, out var p) ? p : 587;

        bool isConfigured = !string.IsNullOrWhiteSpace(password) &&
                            !password.Contains("YOUR_SMTP") &&
                            !password.Contains("PASSWORD");

        return (host, port, senderEmail, senderName, password, enableSsl, isConfigured);
    }

    // The SMTP password is stored encrypted at rest (Data Protection API) since it's a
    // reversible secret we must hand back to SmtpClient, not a one-way hash like a login password.
    private string DecryptPassword(string? storedValue)
    {
        if (string.IsNullOrEmpty(storedValue))
        {
            return string.Empty;
        }

        try
        {
            return _protector.Unprotect(storedValue);
        }
        catch (Exception ex)
        {
            // Covers key-ring rotation as well as pre-encryption legacy rows saved before this
            // protector existed — either way we can't recover the plaintext, so ask for it again
            // instead of sending a garbled password to the SMTP server.
            _logger.LogWarning(ex, "Could not decrypt stored SMTP password. Treating as unconfigured until re-saved via Email Settings.");
            return string.Empty;
        }
    }

    // Blocks the SMTP host from resolving to a private/internal/link-local address so that the
    // configurable host+port here (settable by any admin, and directly user-suppliable via the
    // test-connection endpoint) can't be used as an SSRF primitive to probe internal infrastructure
    // (including cloud metadata endpoints at 169.254.169.254).
    private static async Task<(bool Allowed, string Reason)> ValidateHostAsync(string host, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(host))
        {
            return (false, "SMTP host is required.");
        }

        IPAddress[] addresses;
        try
        {
            addresses = IPAddress.TryParse(host, out var literal)
                ? new[] { literal }
                : await Dns.GetHostAddressesAsync(host, ct);
        }
        catch (Exception ex)
        {
            return (false, $"Could not resolve SMTP host '{host}': {ex.Message}");
        }

        if (addresses.Length == 0)
        {
            return (false, $"SMTP host '{host}' did not resolve to any address.");
        }

        foreach (var ip in addresses)
        {
            if (IsPrivateOrReservedAddress(ip))
            {
                return (false, $"SMTP host '{host}' resolves to a private/internal address ({ip}) and is not allowed.");
            }
        }

        return (true, string.Empty);
    }

    private static bool IsPrivateOrReservedAddress(IPAddress address)
    {
        var ip = address.IsIPv4MappedToIPv6 ? address.MapToIPv4() : address;

        if (IPAddress.IsLoopback(ip))
        {
            return true;
        }

        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
            var b = ip.GetAddressBytes();
            if (b[0] == 0) return true;                                   // 0.0.0.0/8
            if (b[0] == 10) return true;                                  // 10.0.0.0/8
            if (b[0] == 100 && b[1] >= 64 && b[1] <= 127) return true;     // 100.64.0.0/10 (CGNAT)
            if (b[0] == 127) return true;                                 // 127.0.0.0/8
            if (b[0] == 169 && b[1] == 254) return true;                  // 169.254.0.0/16 (link-local, incl. cloud metadata)
            if (b[0] == 172 && b[1] >= 16 && b[1] <= 31) return true;      // 172.16.0.0/12
            if (b[0] == 192 && b[1] == 168) return true;                  // 192.168.0.0/16
            if (b[0] >= 224) return true;                                 // multicast + reserved
        }
        else if (ip.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (ip.IsIPv6LinkLocal || ip.IsIPv6SiteLocal || ip.IsIPv6Multicast) return true;
            var b = ip.GetAddressBytes();
            if ((b[0] & 0xFE) == 0xFC) return true;                       // fc00::/7 (unique local)
        }

        return false;
    }

    public async Task<bool> SendEmailAsync(
        string toEmail,
        string subject,
        string htmlBody,
        byte[]? attachmentBytes = null,
        string? attachmentFileName = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
        {
            _logger.LogWarning("Email recipient address is empty. Skipping email delivery.");
            return false;
        }

        var (host, port, senderEmail, senderName, password, enableSsl, isConfigured) = await ResolveSettingsAsync(ct);

        bool isPlaceholder = !isConfigured ||
                             string.IsNullOrWhiteSpace(host) ||
                             string.IsNullOrWhiteSpace(password) ||
                             password.Contains("YOUR_SMTP") ||
                             password.Contains("PASSWORD");

        if (isPlaceholder)
        {
            _logger.LogInformation(
                "[Notification:Email:Simulated] To: {ToEmail} | Subject: {Subject} | Attachment: {Attachment} | Note: Running in simulated mode (SMTP credentials placeholder or not configured)",
                toEmail,
                subject,
                attachmentFileName ?? "None");
            return true;
        }

        var (hostAllowed, hostBlockReason) = await ValidateHostAsync(host, ct);
        if (!hostAllowed)
        {
            _logger.LogWarning("[Notification:Email:Blocked] {Reason}", hostBlockReason);
            return false;
        }

        try
        {
            using var message = new MailMessage();
            message.From = new MailAddress(senderEmail, senderName);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = subject;
            message.Body = htmlBody;
            message.IsBodyHtml = true;

            MemoryStream? memoryStream = null;
            if (attachmentBytes != null && attachmentBytes.Length > 0 && !string.IsNullOrWhiteSpace(attachmentFileName))
            {
                memoryStream = new MemoryStream(attachmentBytes);
                var attachment = new Attachment(memoryStream, attachmentFileName, "application/pdf");
                message.Attachments.Add(attachment);
            }

            using var client = new SmtpClient(host, port)
            {
                EnableSsl = enableSsl,
                Credentials = new NetworkCredential(senderEmail, password),
                Timeout = 15000 // 15 seconds timeout
            };

            await client.SendMailAsync(message, ct);

            memoryStream?.Dispose();

            _logger.LogInformation("[Notification:Email:Sent] Successfully sent email to {ToEmail} with Subject: {Subject}", toEmail, subject);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "[Notification:Email:Failed] Could not deliver email to {ToEmail}. Subject: {Subject}. Error: {Message}", toEmail, subject, ex.Message);
            return false;
        }
    }

    public async Task<(bool Success, string Message)> SendTestEmailAsync(
        string toEmail,
        string? smtpHost = null,
        int? smtpPort = null,
        string? senderEmail = null,
        string? senderName = null,
        string? smtpPassword = null,
        bool? enableSsl = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
        {
            return (false, "Recipient email address is required.");
        }

        var resolved = await ResolveSettingsAsync(ct);

        var finalHost = !string.IsNullOrWhiteSpace(smtpHost) ? smtpHost : resolved.Host;
        var finalPort = smtpPort.HasValue && smtpPort.Value > 0 ? smtpPort.Value : resolved.Port;
        var finalSenderEmail = !string.IsNullOrWhiteSpace(senderEmail) ? senderEmail : resolved.SenderEmail;
        var finalSenderName = !string.IsNullOrWhiteSpace(senderName) ? senderName : resolved.SenderName;
        var finalSsl = enableSsl ?? resolved.EnableSsl;

        // Password handling: if caller passed a non-empty, unmasked password, use it. Otherwise use saved password.
        string finalPassword = (!string.IsNullOrWhiteSpace(smtpPassword) && !smtpPassword.Contains("•••"))
            ? smtpPassword
            : resolved.Password;

        if (string.IsNullOrWhiteSpace(finalHost))
        {
            return (false, "SMTP Host is missing.");
        }

        if (string.IsNullOrWhiteSpace(finalSenderEmail))
        {
            return (false, "Sender email address is missing.");
        }

        if (string.IsNullOrWhiteSpace(finalPassword) || finalPassword.Contains("YOUR_SMTP"))
        {
            return (false, "SMTP password is not set or contains placeholder text.");
        }

        var (hostAllowed, hostBlockReason) = await ValidateHostAsync(finalHost, ct);
        if (!hostAllowed)
        {
            return (false, hostBlockReason);
        }

        try
        {
            using var message = new MailMessage();
            message.From = new MailAddress(finalSenderEmail, finalSenderName);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = "Himgiri Goods - SMTP Test Email";
            message.Body = $@"
<!DOCTYPE html>
<html>
<head>
  <style>
    body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f8fafc; padding: 20px; }}
    .card {{ background: #ffffff; border-radius: 8px; border: 1px solid #e2e8f0; padding: 24px; max-width: 550px; margin: 0 auto; box-shadow: 0 4px 6px -1px rgba(0,0,0,0.1); }}
    .badge {{ display: inline-block; padding: 4px 12px; background: #dcfce7; color: #166534; font-weight: bold; font-size: 13px; border-radius: 9999px; margin-bottom: 12px; }}
    h2 {{ color: #0f172a; margin-top: 0; }}
    p {{ color: #334155; line-height: 1.5; font-size: 14px; }}
    .details {{ background: #f1f5f9; border-radius: 6px; padding: 12px 16px; margin: 16px 0; font-family: monospace; font-size: 13px; }}
    .footer {{ font-size: 12px; color: #94a3b8; text-align: center; margin-top: 20px; }}
  </style>
</head>
<body>
  <div class='card'>
    <span class='badge'>✓ Configuration Verified</span>
    <h2>SMTP Configuration Test Successful</h2>
    <p>This test email confirms that your outgoing SMTP mail server has been successfully configured and is ready to deliver live order notifications, invoices, and challans.</p>
    <div class='details'>
      <strong>Host:</strong> {finalHost}<br/>
      <strong>Port:</strong> {finalPort}<br/>
      <strong>Sender:</strong> {finalSenderEmail} ({finalSenderName})<br/>
      <strong>SSL/TLS:</strong> {(finalSsl ? "Enabled" : "Disabled")}<br/>
      <strong>Timestamp:</strong> {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC
    </div>
    <p>No further action is required.</p>
    <div class='footer'>Himgiri Goods & Uniforms &bull; System Notification</div>
  </div>
</body>
</html>";
            message.IsBodyHtml = true;

            using var client = new SmtpClient(finalHost, finalPort)
            {
                EnableSsl = finalSsl,
                Credentials = new NetworkCredential(finalSenderEmail, finalPassword),
                Timeout = 12000
            };

            await client.SendMailAsync(message, ct);
            _logger.LogInformation("[Notification:Email:TestSent] Test email sent successfully to {ToEmail} via {Host}:{Port}", toEmail, finalHost, finalPort);
            return (true, $"Test email sent successfully to {toEmail} via {finalHost}:{finalPort}!");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "[Notification:Email:TestFailed] Failed to send test email to {ToEmail}: {Error}", toEmail, ex.Message);
            return (false, $"SMTP connection failed: {ex.Message}");
        }
    }
}

