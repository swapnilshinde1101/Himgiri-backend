using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Himgiri.API.Controllers;

[AllowAnonymous]
public class PaymentsController : BaseController
{
    private readonly IOrderService _orderService;
    private readonly IConfiguration _config;

    public PaymentsController(IOrderService orderService, IConfiguration config)
    {
        _orderService = orderService;
        _config = config;
    }

    [HttpPost("webhook")]
    public async Task<IActionResult> PaymentWebhook(CancellationToken ct)
    {
        // 1. Read raw request body for signature verification
        Request.EnableBuffering();
        using var reader = new System.IO.StreamReader(Request.Body, System.Text.Encoding.UTF8, true, 1024, true);
        var rawBody = await reader.ReadToEndAsync();
        Request.Body.Position = 0; // Reset position for model binder

        var signature = Request.Headers["X-Jodo-Signature"].ToString();
        var secret = _config["Jodo:WebhookSecret"];

        // 2. Perform signature validation if secret is configured and not default placeholder
        if (!string.IsNullOrEmpty(secret) && secret != "YOUR_JODO_WEBHOOK_SECRET")
        {
            if (string.IsNullOrEmpty(signature))
            {
                return BadRequest(JsonModel<bool>.Error("Missing X-Jodo-Signature header."));
            }

            using var hmac = new System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes(secret));
            var hashBytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(rawBody));
            var calculatedSignature = Convert.ToHexString(hashBytes).ToLower();

            if (!string.Equals(calculatedSignature, signature.ToLower(), StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(JsonModel<bool>.Error("Invalid webhook signature."));
            }
        }

        // 3. Deserialize body
        JodoWebhookPayload? payload;
        try
        {
            payload = System.Text.Json.JsonSerializer.Deserialize<JodoWebhookPayload>(rawBody, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch
        {
            return BadRequest(JsonModel<bool>.Error("Invalid payload format."));
        }

        if (payload == null || string.IsNullOrEmpty(payload.OrderId) || string.IsNullOrEmpty(payload.TransactionId))
        {
            return BadRequest(JsonModel<bool>.Error("OrderId and TransactionId are required."));
        }

        if (!Guid.TryParse(payload.OrderId, out var orderId))
        {
            return BadRequest(JsonModel<bool>.Error("Invalid OrderId format. Must be a Guid."));
        }

        // 4. Confirm payment based on transaction status
        if (string.Equals(payload.Status, "SUCCESS", StringComparison.OrdinalIgnoreCase) || 
            string.Equals(payload.Status, "PAID", StringComparison.OrdinalIgnoreCase))
        {
            var result = await _orderService.ConfirmPaymentAsync(orderId, payload.TransactionId, ct);
            return StatusCode(result.StatusCode, result);
        }
        else
        {
            // If payment failed, return success to the gateway indicating we processed the webhook
            return Ok(JsonModel<bool>.Success(true, $"Webhook received with status: {payload.Status}"));
        }
    }
}

public record JodoWebhookPayload(
    string OrderId,
    string TransactionId,
    string Status,
    decimal Amount,
    string Message
);
