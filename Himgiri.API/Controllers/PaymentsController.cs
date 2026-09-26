using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Himgiri.API.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : BaseController
{
    private readonly IOrderService _orderService;
    private readonly IPaymentGateway _paymentGateway;
    private readonly IConfiguration _config;

    public PaymentsController(
        IOrderService orderService,
        IPaymentGateway paymentGateway,
        IConfiguration config)
    {
        _orderService = orderService;
        _paymentGateway = paymentGateway;
        _config = config;
    }

    [HttpPost("initiate")]
    [AllowAnonymous]
    [EnableRateLimiting("PaymentInitiatePolicy")]
    public async Task<IActionResult> InitiatePayment(
        [FromBody] InitiatePaymentRequest request,
        CancellationToken ct)
    {
        var order = await _orderService.GetOrderForPaymentAsync(
            request.OrderId, ct);

        if (order == null)
            return NotFound(JsonModel<object>.Error("Order not found.", 404));

        if (order.PaymentStatus == PaymentStatus.Success)
            return BadRequest(JsonModel<object>.Error("Order is already paid.", 400));

        var token = _orderService.GenerateOrderAccessToken(order.Id);

        var callbackUrl =
            $"{_config["App:FrontendUrl"]}/confirmation/{order.Id}?token={token}";

        var result = await _paymentGateway.CreatePaymentAsync(
            order, callbackUrl, ct);

        await _orderService.SaveJodoOrderIdAsync(
            order.Id, result.JodoOrderId, ct);

        var responseWithToken = new InitiatePaymentResponse(
            result.JodoOrderId,
            result.RedirectUrl,
            token
        );

        return Ok(JsonModel<InitiatePaymentResponse>.Success(responseWithToken));
    }

    [HttpPost("webhook")]
    [AllowAnonymous]
    public async Task<IActionResult> HandleWebhook(CancellationToken ct)
    {
        Request.EnableBuffering();
        using var reader = new StreamReader(
            Request.Body, Encoding.UTF8, leaveOpen: true);
        var rawBody = await reader.ReadToEndAsync();
        Request.Body.Position = 0;

        var receivedSignature =
            Request.Headers["X-Jodo-Signature"].ToString();

        var isValid = await _paymentGateway.VerifyWebhookSignatureAsync(
            rawBody, receivedSignature);

        if (!isValid)
        {
            return Unauthorized(JsonModel<bool>.Error("Invalid webhook signature.", 401));
        }

        JodoWebhookPayload? payload;
        try
        {
            payload = JsonSerializer.Deserialize<JodoWebhookPayload>(
                rawBody,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
        catch
        {
            return BadRequest(JsonModel<bool>.Error("Invalid payload format.", 400));
        }

        if (payload == null)
            return BadRequest(JsonModel<bool>.Error("Invalid payload.", 400));

        if (payload.Event != "order.payment.debited")
            return Ok(JsonModel<bool>.Success(true, "Event ignored."));

        var invoiceNumber = payload.Payload.Order.Notes
            ?.FirstOrDefault(n => n.Key == "erp_reference_id")?.Value;

        if (string.IsNullOrWhiteSpace(invoiceNumber))
            return BadRequest(JsonModel<bool>.Error("Missing erp_reference_id in notes.", 400));

        var jodoOrderId = payload.Payload.OrderId;

        var result = await _orderService.ConfirmPaymentByInvoiceAsync(
            invoiceNumber, jodoOrderId, ct);

        return StatusCode(result.StatusCode, result);
    }
}
