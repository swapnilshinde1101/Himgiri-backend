using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.API.Controllers;

[Authorize(Policy = "AnyAdmin")]
[Route("api/email-settings")]
public class EmailSettingsController : BaseController
{
    private readonly HimgiriDbContext _db;
    private readonly IEmailService _emailService;
    private readonly IDataProtector _protector;

    public EmailSettingsController(HimgiriDbContext db, IEmailService emailService, IDataProtectionProvider dataProtectionProvider)
    {
        _db = db;
        _emailService = emailService;
        // Same purpose string as EmailService — protectors must match to decrypt what's encrypted here.
        _protector = dataProtectionProvider.CreateProtector("Himgiri.EmailSettings.SmtpPassword");
    }

    [HttpGet]
    public async Task<IActionResult> GetSettings(CancellationToken ct)
    {
        var config = await _db.EmailConfigurations.FirstOrDefaultAsync(c => !c.IsDeleted, ct);

        if (config == null)
        {
            config = new EmailConfiguration
            {
                Id = Guid.NewGuid(),
                SmtpHost = "smtp.gmail.com",
                SmtpPort = 587,
                SenderEmail = "noreply@himgirigoods.com",
                SenderName = "Himgiri Goods & Uniforms",
                SmtpPassword = string.Empty,
                EnableSsl = true,
                IsConfigured = false,
                CreatedAt = DateTime.UtcNow
            };
            _db.EmailConfigurations.Add(config);
            await _db.SaveChangesAsync(ct);
        }

        var dto = new EmailSettingsDto(
            config.Id,
            config.SmtpHost,
            config.SmtpPort,
            config.SenderEmail,
            config.SenderName,
            config.EnableSsl,
            config.IsConfigured,
            !string.IsNullOrWhiteSpace(config.SmtpPassword)
        );

        return Ok(JsonModel<EmailSettingsDto>.Success(dto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSettings([FromBody] UpdateEmailSettingsRequest request, CancellationToken ct)
    {
        if (request == null)
        {
            return BadRequest(JsonModel<bool>.Error("Invalid request body."));
        }

        if (string.IsNullOrWhiteSpace(request.SmtpHost))
        {
            return BadRequest(JsonModel<bool>.Error("SMTP Host is required."));
        }

        if (request.SmtpPort <= 0 || request.SmtpPort > 65535)
        {
            return BadRequest(JsonModel<bool>.Error("Valid SMTP Port (1-65535) is required."));
        }

        if (string.IsNullOrWhiteSpace(request.SenderEmail))
        {
            return BadRequest(JsonModel<bool>.Error("Sender Email is required."));
        }

        var config = await _db.EmailConfigurations.FirstOrDefaultAsync(c => !c.IsDeleted, ct);

        if (config == null)
        {
            config = new EmailConfiguration
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };
            _db.EmailConfigurations.Add(config);
        }

        config.SmtpHost = request.SmtpHost.Trim();
        config.SmtpPort = request.SmtpPort;
        config.SenderEmail = request.SenderEmail.Trim();
        config.SenderName = string.IsNullOrWhiteSpace(request.SenderName) ? "Himgiri Goods & Uniforms" : request.SenderName.Trim();
        config.EnableSsl = request.EnableSsl;
        config.IsConfigured = request.IsConfigured;

        // If a new password is provided and not masked, encrypt and store it.
        // (Stored encrypted, not hashed, because SendEmailAsync needs the plaintext back to authenticate with the SMTP server.)
        if (!string.IsNullOrWhiteSpace(request.SmtpPassword) && !request.SmtpPassword.Contains("•••"))
        {
            config.SmtpPassword = _protector.Protect(request.SmtpPassword.Trim());
        }

        // If no password exists, it cannot be considered active
        if (string.IsNullOrWhiteSpace(config.SmtpPassword))
        {
            config.IsConfigured = false;
        }

        config.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync(ct);

        var dto = new EmailSettingsDto(
            config.Id,
            config.SmtpHost,
            config.SmtpPort,
            config.SenderEmail,
            config.SenderName,
            config.EnableSsl,
            config.IsConfigured,
            !string.IsNullOrWhiteSpace(config.SmtpPassword)
        );

        return Ok(JsonModel<EmailSettingsDto>.Success(dto, "Email settings saved successfully."));
    }

    [HttpPost("test")]
    public async Task<IActionResult> TestConnection([FromBody] TestEmailRequest request, CancellationToken ct)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.ToEmail))
        {
            return BadRequest(JsonModel<object>.Error("Recipient email address is required for test."));
        }

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(request.ToEmail.Trim()))
        {
            return BadRequest(JsonModel<object>.Error("Please provide a valid recipient email address."));
        }

        var (success, message) = await _emailService.SendTestEmailAsync(
            request.ToEmail.Trim(),
            request.SmtpHost,
            request.SmtpPort,
            request.SenderEmail,
            request.SenderName,
            request.SmtpPassword,
            request.EnableSsl,
            ct);

        if (!success)
        {
            return BadRequest(JsonModel<object>.Error(message));
        }

        return Ok(JsonModel<object>.Success(new { success = true, message }, message));
    }
}
