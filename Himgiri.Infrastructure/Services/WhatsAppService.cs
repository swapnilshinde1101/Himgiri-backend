using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Himgiri.Infrastructure.Services;

public class WhatsAppService : IWhatsAppService
{
    private readonly IConfiguration _config;
    private readonly ILogger<WhatsAppService> _logger;
    private readonly HttpClient _httpClient;

    public WhatsAppService(IConfiguration config, ILogger<WhatsAppService> logger, HttpClient? httpClient = null)
    {
        _config = config;
        _logger = logger;
        _httpClient = httpClient ?? new HttpClient();
    }

    public async Task<bool> SendWhatsAppMessageAsync(
        string mobileNumber, 
        string messageText, 
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(mobileNumber))
        {
            _logger.LogWarning("WhatsApp recipient mobile number is empty. Skipping delivery.");
            return false;
        }

        var enabledStr = _config["WhatsApp:Enabled"];
        bool isEnabled = !bool.TryParse(enabledStr, out var en) || en;
        if (!isEnabled)
        {
            _logger.LogInformation("[Notification:WhatsApp:Disabled] WhatsApp service is disabled in configuration.");
            return false;
        }

        // Normalize mobile number for Indian format
        string normalizedPhone = mobileNumber.Trim().Replace(" ", "").Replace("-", "");
        if (normalizedPhone.Length == 10)
        {
            normalizedPhone = "+91" + normalizedPhone;
        }
        else if (normalizedPhone.Length == 12 && normalizedPhone.StartsWith("91"))
        {
            normalizedPhone = "+" + normalizedPhone;
        }

        var provider = _config["WhatsApp:Provider"] ?? "Simulated";
        var apiUrl = _config["WhatsApp:ApiUrl"];
        var apiKey = _config["WhatsApp:ApiKey"];

        bool isSimulated = provider.Equals("Simulated", StringComparison.OrdinalIgnoreCase) ||
                           string.IsNullOrWhiteSpace(apiUrl) || 
                           string.IsNullOrWhiteSpace(apiKey) || 
                           apiKey.Contains("YOUR_WHATSAPP");

        if (isSimulated)
        {
            _logger.LogInformation(
                "[Notification:WhatsApp:Simulated]\nRecipient: {Recipient}\n----------------- MESSAGE CONTENT -----------------\n{MessageText}\n---------------------------------------------------",
                normalizedPhone,
                messageText);
            return true;
        }

        try
        {
            var payload = new
            {
                to = normalizedPhone,
                text = new { body = messageText }
            };

            var json = JsonSerializer.Serialize(payload);
            using var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.Headers.Add("Authorization", $"Bearer {apiKey}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request, ct);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("[Notification:WhatsApp:Sent] Successfully sent WhatsApp message to {Recipient}", normalizedPhone);
                return true;
            }

            var errContent = await response.Content.ReadAsStringAsync(ct);
            _logger.LogWarning("[Notification:WhatsApp:Failed] HTTP {StatusCode} when sending to {Recipient}: {Error}", response.StatusCode, normalizedPhone, errContent);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "[Notification:WhatsApp:Error] Failed to dispatch WhatsApp message to {Recipient}: {Message}", normalizedPhone, ex.Message);
            return false;
        }
    }
}
