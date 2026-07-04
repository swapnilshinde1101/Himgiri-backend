using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Himgiri.API.Controllers;

[Authorize]
public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;
    private readonly IConfiguration _config;

    public OrdersController(IOrderService orderService, IConfiguration config)
    {
        _orderService = orderService;
        _config = config;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken ct)
    {
        var result = await _orderService.CreateOrderAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetOrder(Guid id, CancellationToken ct)
    {
        var result = await _orderService.GetOrderByIdAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetOrders([FromQuery] OrderQueryRequest request, CancellationToken ct)
    {
        var result = await _orderService.GetPagedOrdersAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/status")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] OrderStatusDto request, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.UpdateOrderStatusAsync(id, request, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("{id:guid}/notes")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> AddNote(Guid id, [FromBody] AddOrderNoteRequest request, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.AddOrderNoteAsync(id, request, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/stockout")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> FlagStockOut(Guid id, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.FlagStockOutAsync(id, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/refund")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> ProcessRefund(Guid id, [FromBody] ProcessRefundRequest request, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.ProcessRefundAsync(id, request, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("export/csv")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> ExportCsv(CancellationToken ct)
    {
        var csvBytes = await _orderService.ExportOrdersToCsvAsync(ct);
        var filename = $"Orders_Export_{System.DateTime.UtcNow:yyyyMMdd_HHmmss}.csv";
        return File(csvBytes, "text/csv", filename);
    }

    [HttpGet("{id:guid}/invoice")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> DownloadInvoice(Guid id, [FromServices] IInvoiceService invoiceService, CancellationToken ct)
    {
        var result = await invoiceService.GenerateInvoiceAsync(id, ct);
        if (result.StatusCode != 200 || result.Data == null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return File(result.Data.PdfContent, result.Data.ContentType, $"Invoice_{result.Data.InvoiceNumber}.pdf");
    }

    [HttpGet("customers")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetCustomers(CancellationToken ct)
    {
        var result = await _orderService.GetCustomersAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("customers/{mobile}")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetCustomerOrders(string mobile, CancellationToken ct)
    {
        var result = await _orderService.GetOrdersByCustomerAsync(mobile, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("webhook")]
    [AllowAnonymous]
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
