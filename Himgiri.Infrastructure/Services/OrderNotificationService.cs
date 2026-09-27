using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Himgiri.Infrastructure.Services;

public class OrderNotificationService : IOrderNotificationService
{
    private readonly HimgiriDbContext _db;
    private readonly IEmailService _emailService;
    private readonly IWhatsAppService _whatsAppService;
    private readonly IInvoiceService _invoiceService;
    private readonly IOrderService _orderService;
    private readonly IConfiguration _config;
    private readonly ILogger<OrderNotificationService> _logger;

    public OrderNotificationService(
        HimgiriDbContext db,
        IEmailService emailService,
        IWhatsAppService whatsAppService,
        IInvoiceService invoiceService,
        IOrderService orderService,
        IConfiguration config,
        ILogger<OrderNotificationService> logger)
    {
        _db = db;
        _emailService = emailService;
        _whatsAppService = whatsAppService;
        _invoiceService = invoiceService;
        _orderService = orderService;
        _config = config;
        _logger = logger;
    }

    // These templates interpolate customer-supplied free text (name, address, cancellation reason)
    // straight into HTML sent from our own domain — encode it so a crafted name/address can't
    // inject markup into an email a recipient might view, forward, or reply-all on.
    private static string Enc(string? value) => WebUtility.HtmlEncode(value ?? string.Empty);

    private string GetApiBaseUrl()
    {
        return _config["App:ApiBaseUrl"] ?? "https://localhost:62313";
    }

    private string GetFrontendBaseUrl()
    {
        return _config["AllowedOrigins"]?.Split(',').FirstOrDefault()?.Trim() ?? "http://localhost:5173";
    }

    public async Task<JsonModel<bool>> SendOrderConfirmationAsync(Guid orderId, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
        {
            _logger.LogWarning("Cannot send confirmation: Order {OrderId} not found.", orderId);
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        string token = _orderService.GenerateOrderAccessToken(order.Id);
        string apiBase = GetApiBaseUrl();
        string frontendBase = GetFrontendBaseUrl();
        string invoiceUrl = $"{apiBase}/api/orders/{order.Id}/invoice?token={token}";
        string portalLookupUrl = $"{frontendBase}/?lookup=true&mobile={order.Mobile}&pincode={order.Pincode}";

        // 1. Generate Tax Invoice PDF
        byte[]? invoicePdf = null;
        var invoiceRes = await _invoiceService.GenerateInvoiceAsync(order.Id, ct);
        if (invoiceRes.StatusCode == 200 && invoiceRes.Data != null)
        {
            invoicePdf = invoiceRes.Data.PdfContent;
        }

        // 2. Build and send HTML Email
        string emailSubject = $"Order Confirmed & Tax Invoice - {order.InvoiceNumber} | Himgiri Goods";
        string emailBody = BuildOrderConfirmationEmailHtml(order, invoiceUrl, portalLookupUrl);

        bool emailSent = false;
        if (!string.IsNullOrWhiteSpace(order.Email))
        {
            emailSent = await _emailService.SendEmailAsync(
                order.Email,
                emailSubject,
                emailBody,
                invoicePdf,
                $"Invoice_{order.InvoiceNumber}.pdf",
                ct);
        }

        // 3. Build and send WhatsApp Message
        string whatsappMsg = BuildOrderConfirmationWhatsAppText(order, invoiceUrl, portalLookupUrl);
        bool whatsappSent = false;
        if (!string.IsNullOrWhiteSpace(order.Mobile))
        {
            whatsappSent = await _whatsAppService.SendWhatsAppMessageAsync(order.Mobile, whatsappMsg, ct);
        }

        // 4. Log in order status history
        _db.OrderStatusHistories.Add(new OrderStatusHistory
        {
            OrderId = order.Id,
            FromStatus = order.Status,
            ToStatus = order.Status,
            ChangedBy = "Notification Service",
            Note = $"Order confirmation notification dispatched: Email={(emailSent ? "Sent" : "Skipped/Failed")}, WhatsApp={(whatsappSent ? "Sent" : "Skipped/Failed")}",
            CreatedAt = DateTime.UtcNow
        });

        await _db.SaveChangesAsync(ct);
        return JsonModel<bool>.Success(true, "Order confirmation notifications processed.");
    }

    public async Task<JsonModel<bool>> SendOrderDispatchedAsync(Guid orderId, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
        {
            _logger.LogWarning("Cannot send dispatch notification: Order {OrderId} not found.", orderId);
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        string token = _orderService.GenerateOrderAccessToken(order.Id);
        string apiBase = GetApiBaseUrl();
        string frontendBase = GetFrontendBaseUrl();
        string challanUrl = $"{apiBase}/api/orders/{order.Id}/delivery-challan?token={token}";
        string portalLookupUrl = $"{frontendBase}/?lookup=true&mobile={order.Mobile}&pincode={order.Pincode}";

        // 1. Generate Delivery Challan PDF
        byte[]? challanPdf = null;
        var challanRes = await _invoiceService.GenerateDeliveryChallanAsync(order.Id, ct);
        if (challanRes.StatusCode == 200 && challanRes.Data != null)
        {
            challanPdf = challanRes.Data.PdfContent;
        }

        // 2. Build and send HTML Email
        string emailSubject = $"Order Dispatched & Delivery Challan - {order.InvoiceNumber} | Himgiri Goods";
        string emailBody = BuildOrderDispatchedEmailHtml(order, challanUrl, portalLookupUrl);

        bool emailSent = false;
        if (!string.IsNullOrWhiteSpace(order.Email))
        {
            emailSent = await _emailService.SendEmailAsync(
                order.Email,
                emailSubject,
                emailBody,
                challanPdf,
                $"DeliveryChallan_{order.InvoiceNumber}.pdf",
                ct);
        }

        // 3. Build and send WhatsApp Message
        string whatsappMsg = BuildOrderDispatchedWhatsAppText(order, challanUrl);
        bool whatsappSent = false;
        if (!string.IsNullOrWhiteSpace(order.Mobile))
        {
            whatsappSent = await _whatsAppService.SendWhatsAppMessageAsync(order.Mobile, whatsappMsg, ct);
        }

        // 4. Log in order status history
        _db.OrderStatusHistories.Add(new OrderStatusHistory
        {
            OrderId = order.Id,
            FromStatus = order.Status,
            ToStatus = order.Status,
            ChangedBy = "Notification Service",
            Note = $"Dispatch notification dispatched: Email={(emailSent ? "Sent" : "Skipped/Failed")}, WhatsApp={(whatsappSent ? "Sent" : "Skipped/Failed")}",
            CreatedAt = DateTime.UtcNow
        });

        await _db.SaveChangesAsync(ct);
        return JsonModel<bool>.Success(true, "Dispatch notifications processed.");
    }

    public async Task<JsonModel<bool>> SendOrderCancelledAsync(Guid orderId, string reason, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
        {
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        string emailSubject = $"Order Update: Cancelled - {order.InvoiceNumber} | Himgiri Goods";
        string emailBody = $@"
        <div style=""font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #E2E8F0; border-radius: 8px;"">
            <h2 style=""color: #DC2626;"">Order Cancellation Notice</h2>
            <p>Dear {Enc(order.CustomerName)},</p>
            <p>Your order <strong>{order.InvoiceNumber}</strong> has been cancelled.</p>
            <p><strong>Reason:</strong> {Enc(reason)}</p>
            <p>If you have already paid, your refund will be processed in accordance with our refund policy.</p>
            <p>For assistance, please contact Himgiri support.</p>
        </div>";

        if (!string.IsNullOrWhiteSpace(order.Email))
        {
            await _emailService.SendEmailAsync(order.Email, emailSubject, emailBody, null, null, ct);
        }

        string whatsappMsg = $"⚠️ *Himgiri Order Update*\nHello *{order.CustomerName}*,\n\nYour order *{order.InvoiceNumber}* has been cancelled.\n*Reason:* {reason}\n\nPlease contact support for any questions.";
        if (!string.IsNullOrWhiteSpace(order.Mobile))
        {
            await _whatsAppService.SendWhatsAppMessageAsync(order.Mobile, whatsappMsg, ct);
        }

        return JsonModel<bool>.Success(true, "Cancellation notification processed.");
    }

    // ── Template Generators ──

    private string BuildOrderConfirmationEmailHtml(Order order, string invoiceUrl, string portalUrl)
    {
        var itemsRows = new StringBuilder();
        foreach (var item in order.Items)
        {
            itemsRows.Append($@"
                <tr>
                    <td style=""padding: 8px 12px; border-bottom: 1px solid #E2E8F0;"">{Enc(item.ItemName)}</td>
                    <td style=""padding: 8px 12px; border-bottom: 1px solid #E2E8F0; text-align: center;"">{item.Quantity}</td>
                    <td style=""padding: 8px 12px; border-bottom: 1px solid #E2E8F0; text-align: right;"">₹{item.UnitPrice:0.00}</td>
                    <td style=""padding: 8px 12px; border-bottom: 1px solid #E2E8F0; text-align: right; font-weight: bold;"">₹{item.LineTotal:0.00}</td>
                </tr>");
        }

        return $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset=""utf-8"">
            <style>
                body {{ font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; color: #1E293B; margin: 0; padding: 20px; background-color: #F8FAFC; }}
                .container {{ max-width: 600px; margin: 0 auto; background: #FFFFFF; border-radius: 12px; overflow: hidden; border: 1px solid #E2E8F0; box-shadow: 0 4px 6px -1px rgba(0,0,0,0.05); }}
                .header {{ background: #0F172A; color: #FFFFFF; padding: 24px; text-align: center; }}
                .content {{ padding: 24px; }}
                .card {{ background: #F8FAFC; border: 1px solid #E2E8F0; border-radius: 8px; padding: 16px; margin: 16px 0; }}
                .btn {{ display: inline-block; background: #0284C7; color: #FFFFFF !important; font-weight: bold; text-decoration: none; padding: 12px 24px; border-radius: 8px; text-align: center; margin: 12px 0; }}
                table {{ width: 100%; border-collapse: collapse; margin: 16px 0; font-size: 13px; }}
                th {{ background: #F1F5F9; padding: 10px 12px; text-align: left; font-size: 11px; text-transform: uppercase; color: #64748B; }}
            </style>
        </head>
        <body>
            <div class=""container"">
                <div class=""header"">
                    <h1 style=""margin: 0; font-size: 20px; font-weight: 800; letter-spacing: 0.5px;"">HIMGIRI GOODS & UNIFORMS</h1>
                    <p style=""margin: 4px 0 0 0; font-size: 12px; color: #94A3B8;"">Official School Kit Distribution Partner</p>
                </div>
                <div class=""content"">
                    <div style=""text-align: center; margin-bottom: 20px;"">
                        <span style=""background: #DCFCE7; color: #15803D; font-weight: bold; font-size: 12px; padding: 4px 12px; border-radius: 9999px; text-transform: uppercase;"">✓ Payment Confirmed</span>
                        <h2 style=""color: #0F172A; margin: 12px 0 4px 0;"">Thank You for Your Order!</h2>
                        <p style=""color: #64748B; font-size: 14px; margin: 0;"">Order Reference: <strong>{order.InvoiceNumber}</strong></p>
                    </div>

                    <p>Dear <strong>{Enc(order.CustomerName)}</strong>,</p>
                    <p>We are pleased to confirm your order for <strong>Grade {Enc(order.GradeName)}</strong>. Your payment of <strong>₹{order.GrandTotal:0.00}</strong> has been received successfully.</p>

                    <div class=""card"">
                        <div style=""font-size: 12px; color: #64748B; font-weight: bold; text-transform: uppercase; margin-bottom: 8px;"">Order & Fulfillment Summary</div>
                        <div><strong>Fulfillment Mode:</strong> {(order.IsHomeDelivery ? "🏠 Home Delivery (Courier)" : "🏫 School Classroom Handover")}</div>
                        <div><strong>Contact Phone:</strong> {Enc(order.Mobile)}</div>
                        {(order.IsHomeDelivery ? $"<div><strong>Shipping Address:</strong> {Enc(order.AddressLine1)}, {Enc(order.City)} - {Enc(order.Pincode)}</div>" : $"<div><strong>Campus:</strong> DPS Hinjawadi (Classroom Handover to Student)</div>")}
                    </div>

                    <table>
                        <thead>
                            <tr>
                                <th>Item Description</th>
                                <th style=""text-align: center;"">Qty</th>
                                <th style=""text-align: right;"">Rate</th>
                                <th style=""text-align: right;"">Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            {itemsRows}
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan=""3"" style=""padding: 10px 12px; text-align: right; font-weight: bold;"">Grand Total (Incl. GST):</td>
                                <td style=""padding: 10px 12px; text-align: right; font-weight: bold; color: #0F172A;"">₹{order.GrandTotal:0.00}</td>
                            </tr>
                        </tfoot>
                    </table>

                    <div style=""text-align: center; margin: 24px 0;"">
                        <a href=""{invoiceUrl}"" class=""btn"">📄 Download Official Tax Invoice (PDF)</a>
                    </div>

                    <p style=""font-size: 12px; color: #64748B; text-align: center;"">
                        Your official GST Tax Invoice is also attached to this email.<br/>
                        You can track your order status anytime at our <a href=""{portalUrl}"" style=""color: #0284C7;"">Parent Portal</a>.
                    </p>
                </div>
            </div>
        </body>
        </html>";
    }

    private string BuildOrderDispatchedEmailHtml(Order order, string challanUrl, string portalUrl)
    {
        return $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset=""utf-8"">
            <style>
                body {{ font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; color: #1E293B; margin: 0; padding: 20px; background-color: #F8FAFC; }}
                .container {{ max-width: 600px; margin: 0 auto; background: #FFFFFF; border-radius: 12px; overflow: hidden; border: 1px solid #E2E8F0; box-shadow: 0 4px 6px -1px rgba(0,0,0,0.05); }}
                .header {{ background: #0284C7; color: #FFFFFF; padding: 24px; text-align: center; }}
                .content {{ padding: 24px; }}
                .card {{ background: #F0F9FF; border: 1px solid #BAE6FD; border-radius: 8px; padding: 16px; margin: 16px 0; }}
                .btn {{ display: inline-block; background: #0F172A; color: #FFFFFF !important; font-weight: bold; text-decoration: none; padding: 12px 24px; border-radius: 8px; text-align: center; margin: 12px 0; }}
            </style>
        </head>
        <body>
            <div class=""container"">
                <div class=""header"">
                    <h1 style=""margin: 0; font-size: 20px; font-weight: 800;"">HIMGIRI DISPATCH & LOGISTICS</h1>
                    <p style=""margin: 4px 0 0 0; font-size: 12px; opacity: 0.9;"">Order Fulfillment & Delivery Manifest</p>
                </div>
                <div class=""content"">
                    <div style=""text-align: center; margin-bottom: 20px;"">
                        <span style=""background: #E0F2FE; color: #0369A1; font-weight: bold; font-size: 12px; padding: 4px 12px; border-radius: 9999px; text-transform: uppercase;"">🚚 Order Dispatched</span>
                        <h2 style=""color: #0F172A; margin: 12px 0 4px 0;"">Your Package is On Its Way!</h2>
                        <p style=""color: #64748B; font-size: 14px; margin: 0;"">Order Reference: <strong>{order.InvoiceNumber}</strong></p>
                    </div>

                    <p>Dear <strong>{Enc(order.CustomerName)}</strong>,</p>
                    <p>Great news! Your school kit and uniform package for <strong>Grade {Enc(order.GradeName)}</strong> has been packaged and dispatched.</p>

                    <div class=""card"">
                        <div style=""font-size: 12px; color: #0369A1; font-weight: bold; text-transform: uppercase; margin-bottom: 8px;"">Dispatch Details</div>
                        <div><strong>Fulfillment Mode:</strong> {(order.IsHomeDelivery ? "🏠 Courier Home Delivery" : "🏫 Classroom Handover (DPS Hinjawadi)")}</div>
                        <div><strong>Total Units:</strong> {order.Items.Sum(i => i.Quantity)} items</div>
                        {(order.IsHomeDelivery ? $"<div><strong>Delivery Destination:</strong> {Enc(order.AddressLine1)}, {Enc(order.City)} - {Enc(order.Pincode)}</div>" : $"<div><strong>Handover Location:</strong> Directly inside student's classroom (Grade {Enc(order.GradeName)})</div>")}
                    </div>

                    <div style=""text-align: center; margin: 24px 0;"">
                        <a href=""{challanUrl}"" class=""btn"">📋 Download Delivery Challan & Manifest (PDF)</a>
                    </div>

                    <p style=""font-size: 12px; color: #64748B; text-align: center;"">
                        The official Rule 55 Goods Delivery Challan is attached to this email.<br/>
                        Track real-time status in the <a href=""{portalUrl}"" style=""color: #0284C7;"">Parent Portal</a>.
                    </p>
                </div>
            </div>
        </body>
        </html>";
    }

    private string BuildOrderConfirmationWhatsAppText(Order order, string invoiceUrl, string portalUrl)
    {
        return $@"🎓 *Himgiri School Supplies*
Hello *{order.CustomerName}*,

Your order *{order.InvoiceNumber}* for *Grade {order.GradeName}* is *CONFIRMED*!

💰 *Amount Paid:* ₹{order.GrandTotal:0.00}
📦 *Delivery Mode:* {(order.IsHomeDelivery ? "Home Delivery (Courier)" : "School Classroom Handover")}
🎒 *Items:* {order.Items.Sum(i => i.Quantity)} units

📄 *Download Tax Invoice (PDF):*
{invoiceUrl}

🔍 *Track Order Status:*
{portalUrl}

Thank you for choosing Himgiri!";
    }

    private string BuildOrderDispatchedWhatsAppText(Order order, string challanUrl)
    {
        string dest = order.IsHomeDelivery 
            ? $"{order.AddressLine1}, {order.City}" 
            : $"DPS Hinjawadi Classroom ({order.GradeName})";

        return $@"🚚 *Himgiri Delivery Update*
Hello *{order.CustomerName}*,

Your package for order *{order.InvoiceNumber}* has been *DISPATCHED*!

📍 *Destination:* {dest}
🎓 *Student Grade:* {order.GradeName}
📦 *Total Package Units:* {order.Items.Sum(i => i.Quantity)} pcs

📋 *Download Delivery Challan & Manifest:*
{challanUrl}

Please retain this challan for package verification upon receipt.";
    }
}
