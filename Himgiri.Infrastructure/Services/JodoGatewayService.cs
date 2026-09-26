using Himgiri.Core.Entities;
using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Himgiri.Infrastructure.Services;

public class JodoGatewayService : IPaymentGateway
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public JodoGatewayService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public async Task<InitiatePaymentResponse> CreatePaymentAsync(
        Order order,
        string callbackUrl,
        CancellationToken ct = default)
    {
        var token = _config["Jodo:ApiKey"];
        var baseUrl = _config["Jodo:BaseUrl"];

        var body = new
        {
            name = order.CustomerName,
            phone = order.Mobile,
            email = order.Email,
            details = new[]
            {
                new
                {
                    component_type = "School Kit Payment",
                    amount = order.GrandTotal
                }
            },
            callback_url = callbackUrl,
            notes = new[]
            {
                new { key = "erp_reference_id", value = order.InvoiceNumber }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/api/v1/integrations/pay/orders")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);

        var response = await _http.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<JodoCreateOrderResponse>(
                cancellationToken: ct);

        return new InitiatePaymentResponse(
            result!.Data.OrderId,
            result.Data.RedirectUrl
        );
    }

    public Task<bool> VerifyWebhookSignatureAsync(
        string rawBody,
        string receivedSignature)
    {
        var secret = _config["Jodo:WebhookSecret"];

        if (string.IsNullOrEmpty(secret))
        {
            return Task.FromResult(false);
        }

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var computedBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawBody));
        var expectedSignature = Convert.ToHexString(computedBytes).ToLower();

        // MUST use constant-time comparison — prevents timing attacks
        var result = CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expectedSignature),
            Encoding.UTF8.GetBytes(receivedSignature ?? string.Empty)
        );

        return Task.FromResult(result);
    }
}
