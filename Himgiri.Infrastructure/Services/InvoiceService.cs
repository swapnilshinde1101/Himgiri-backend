using System;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Services;

public class InvoiceService : IInvoiceService
{
    private readonly HimgiriDbContext _db;

    public InvoiceService(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task<JsonModel<InvoicePdfDto>> GenerateInvoiceAsync(Guid orderId, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
        {
            return JsonModel<InvoicePdfDto>.Error("Order not found.", 404);
        }

        // ── Validate Vendor GSTIN is not pending or placeholder before generating legal invoice document ──
        if (string.IsNullOrWhiteSpace(order.SellerGstin) || 
            order.SellerGstin.Contains("PENDING") || 
            order.SellerGstin.Contains("GSTIN_") || 
            order.SellerGstin.Length != 15)
        {
            return JsonModel<InvoicePdfDto>.Error("Invoice generation blocked. Vendor GSTIN is in a pending or invalid state.", 500);
        }

        // Mock PDF bytes generation for now (under development)
        byte[] pdfBytes = System.Text.Encoding.UTF8.GetBytes($"Invoice Content for {order.InvoiceNumber}");

        var dto = new InvoicePdfDto(order.InvoiceNumber, pdfBytes, "application/pdf");
        return JsonModel<InvoicePdfDto>.Success(dto, "Invoice PDF generated successfully.");
    }
}
