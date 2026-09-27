using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Himgiri.Infrastructure.Services;

public class ReportService : IReportService
{
    private readonly HimgiriDbContext _db;
    private readonly ILogger<ReportService>? _logger;

    public ReportService(HimgiriDbContext db, ILogger<ReportService>? logger = null)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<JsonModel<AccountReportSummaryDto>> GetAccountReportSummaryAsync(
        DateTime? startDate = null, 
        DateTime? endDate = null, 
        CancellationToken ct = default)
    {
        try
        {
            var query = _db.Orders.Where(o => !o.IsDeleted);

            if (startDate.HasValue)
            {
                var utcStart = DateTime.SpecifyKind(startDate.Value.Date, DateTimeKind.Utc);
                query = query.Where(o => o.CreatedAt >= utcStart);
            }

            if (endDate.HasValue)
            {
                var utcEnd = DateTime.SpecifyKind(endDate.Value.Date.AddDays(1), DateTimeKind.Utc);
                query = query.Where(o => o.CreatedAt < utcEnd);
            }

            // Paid Orders Metrics (excluding refunded orders)
            var paidOrdersList = await query
                .Where(o => o.PaymentStatus == PaymentStatus.Success && o.Status != OrderStatus.Refunded && !o.IsRefunded)
                .Include(o => o.Grade)
                .Include(o => o.Items)
                .ToListAsync(ct);

            var totalPaidSales = paidOrdersList.Sum(o => o.GrandTotal);
            var totalPaidOrdersCount = paidOrdersList.Count;

            // GST Calculations on paid orders
            var totalGstCollected = paidOrdersList.Sum(o => o.TotalGst);
            var totalCgst = Math.Round(totalGstCollected / 2m, 2);
            var totalSgst = totalGstCollected - totalCgst;
            var totalIgst = 0m;
            var totalNetSales = totalPaidSales - totalGstCollected;

            // Unpaid Receivables (Pending orders awaiting customer payment)
            var pendingGrandTotals = await query
                .Where(o => o.PaymentStatus == PaymentStatus.Pending && o.Status == OrderStatus.Pending)
                .Select(o => o.GrandTotal)
                .ToListAsync(ct);
            var unpaidReceivables = pendingGrandTotals.Sum();
            var pendingOrdersCount = pendingGrandTotals.Count;

            // Refunds
            var refundedGrandTotals = await query
                .Where(o => o.Status == OrderStatus.Refunded || o.IsRefunded)
                .Select(o => o.GrandTotal)
                .ToListAsync(ct);
            var totalRefunded = refundedGrandTotals.Sum();
            var refundedOrdersCount = refundedGrandTotals.Count;

            // Grade Sales Aggregation (for paid orders)
            var gradeSalesData = paidOrdersList
                .Where(o => o.GradeId != null)
                .GroupBy(o => new { GradeId = o.GradeId!.Value, GradeName = o.Grade != null ? o.Grade.Name : "General" })
                .Select(g => new GradeSalesSummaryDto(
                    g.Key.GradeId,
                    g.Key.GradeName,
                    g.Count(),
                    g.Sum(o => o.GrandTotal),
                    g.Sum(o => o.Items.Sum(i => i.Quantity))
                ))
                .OrderByDescending(g => g.TotalSales)
                .ToList();

            // Payment Status Breakdown
            var paymentRows = await query
                .Select(o => new { o.PaymentStatus, o.GrandTotal })
                .ToListAsync(ct);

            var paymentBreakdown = paymentRows
                .GroupBy(o => o.PaymentStatus)
                .Select(g => new PaymentStatusSummaryDto(
                    g.Key.ToString(),
                    g.Count(),
                    g.Sum(o => o.GrandTotal)
                ))
                .ToList();

            var summary = new AccountReportSummaryDto(
                TotalPaidSales: totalPaidSales,
                TotalPaidOrdersCount: totalPaidOrdersCount,
                UnpaidReceivables: unpaidReceivables,
                PendingOrdersCount: pendingOrdersCount,
                TotalRefunded: totalRefunded,
                RefundedOrdersCount: refundedOrdersCount,
                TotalGstCollected: totalGstCollected,
                TotalCgst: totalCgst,
                TotalSgst: totalSgst,
                TotalIgst: totalIgst,
                TotalNetSales: totalNetSales,
                GradeSales: gradeSalesData,
                PaymentBreakdown: paymentBreakdown
            );

            return JsonModel<AccountReportSummaryDto>.Success(summary, "Accounting report generated successfully.");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error generating accounting report summary.");
            return JsonModel<AccountReportSummaryDto>.Error("Failed to calculate accounting report aggregations.", 500);
        }
    }

    public async Task<JsonModel<InventoryValuationReportDto>> GetInventoryValuationReportAsync(CancellationToken ct = default)
    {
        try
        {
            var globalDefault = await _db.VendorSettings
                .Select(vs => vs.DefaultLowStockThreshold)
                .FirstOrDefaultAsync(ct);
            if (globalDefault <= 0)
            {
                globalDefault = 10;
            }

            var totalItemsCount = await _db.Items.CountAsync(i => !i.IsDeleted, ct);

            // Fetch lightweight flat projection of active stock items to compute valuation accurately
            var stockItems = await _db.Items
                .Where(i => !i.IsDeleted && i.IsStockInitialized)
                .Select(i => new
                {
                    i.Id,
                    i.CategoryId,
                    CategoryName = i.Category != null ? i.Category.Name : "Uncategorized",
                    i.StockQty,
                    PurchasePrice = i.PurchasePrice ?? 0m,
                    i.Mrp,
                    i.LowStockThreshold
                })
                .ToListAsync(ct);

            var totalStockQty = stockItems.Sum(i => i.StockQty);
            var totalPurchaseValue = stockItems.Sum(i => (decimal)i.StockQty * i.PurchasePrice);
            var totalRetailValue = stockItems.Sum(i => (decimal)i.StockQty * i.Mrp);
            var totalPotentialMargin = totalRetailValue - totalPurchaseValue;

            var lowStockCount = stockItems.Count(i => i.StockQty > 0 && i.StockQty < (i.LowStockThreshold ?? globalDefault));
            var outOfStockCount = stockItems.Count(i => i.StockQty <= 0);

            var categoryBreakdown = stockItems
                .GroupBy(i => new { i.CategoryId, i.CategoryName })
                .Select(g => new CategoryValuationDto(
                    g.Key.CategoryId,
                    g.Key.CategoryName,
                    g.Count(),
                    g.Sum(i => i.StockQty),
                    g.Sum(i => (decimal)i.StockQty * i.PurchasePrice),
                    g.Sum(i => (decimal)i.StockQty * i.Mrp),
                    g.Sum(i => (decimal)i.StockQty * i.Mrp) - g.Sum(i => (decimal)i.StockQty * i.PurchasePrice)
                ))
                .OrderByDescending(c => c.TotalRetailValue)
                .ToList();

            var valuation = new InventoryValuationReportDto(
                TotalItemsCount: totalItemsCount,
                TotalStockQty: totalStockQty,
                TotalPurchaseValue: totalPurchaseValue,
                TotalRetailValue: totalRetailValue,
                TotalPotentialMargin: totalPotentialMargin,
                LowStockCount: lowStockCount,
                OutOfStockCount: outOfStockCount,
                CategoryBreakdown: categoryBreakdown
            );

            return JsonModel<InventoryValuationReportDto>.Success(valuation, "Inventory valuation report generated successfully.");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error generating inventory valuation report.");
            return JsonModel<InventoryValuationReportDto>.Error("Failed to calculate inventory valuation aggregations.", 500);
        }
    }

    public async Task<JsonModel<StaffActivityReportDto>> GetStaffActivityReportAsync(int limit = 50, CancellationToken ct = default)
    {
        try
        {
            if (limit <= 0) limit = 50;
            if (limit > 200) limit = 200;

            // Real Staff Directory from AdminUsers
            var staffMembers = await _db.AdminUsers
                .Where(u => !u.IsDeleted)
                .OrderBy(u => u.Name)
                .Select(u => new StaffUserDto(
                    u.Id,
                    u.Name,
                    u.Email,
                    u.Role.ToString(),
                    u.LastLoginAt,
                    u.IsActive
                ))
                .ToListAsync(ct);

            // Live Activity Stream from OrderStatusHistories, StockLogs, and PriceAuditLogs
            var orderHistories = await _db.OrderStatusHistories
                .Include(h => h.Order)
                .OrderByDescending(h => h.CreatedAt)
                .Take(limit)
                .Select(h => new StaffActivityLogDto(
                    h.Id.ToString(),
                    string.IsNullOrWhiteSpace(h.ChangedBy) ? "System" : h.ChangedBy,
                    h.ToStatus == OrderStatus.Refunded ? "Processed Refund" : $"Order Status: {h.ToStatus}",
                    h.Note ?? $"Order transitioned from {h.FromStatus} to {h.ToStatus}",
                    h.Order != null ? h.Order.InvoiceNumber : "Order",
                    h.CreatedAt
                ))
                .ToListAsync(ct);

            var stockLogs = await _db.StockLogs
                .Include(l => l.Item)
                .OrderByDescending(l => l.CreatedAt)
                .Take(limit)
                .Select(l => new StaffActivityLogDto(
                    l.Id.ToString(),
                    string.IsNullOrWhiteSpace(l.ChangedBy) ? "System" : l.ChangedBy,
                    "Stock Level Adjusted",
                    $"{l.OldQty} -> {l.NewQty} ({(l.NewQty >= l.OldQty ? "+" : "")}{l.NewQty - l.OldQty}) - {l.Reason}{(string.IsNullOrEmpty(l.Note) ? "" : " | " + l.Note)}",
                    l.Item != null ? l.Item.Name : "Item",
                    l.CreatedAt
                ))
                .ToListAsync(ct);

            var priceLogs = await _db.PriceAuditLogs
                .Include(p => p.Item)
                .OrderByDescending(p => p.CreatedAt)
                .Take(limit)
                .Select(p => new StaffActivityLogDto(
                    p.Id.ToString(),
                    string.IsNullOrWhiteSpace(p.ChangedBy) ? "System" : p.ChangedBy,
                    "Price / MRP Adjusted",
                    $"Price: ₹{p.OldPrice} -> ₹{p.NewPrice} | MRP: ₹{p.OldMrp} -> ₹{p.NewMrp} - {p.Reason}",
                    p.Item != null ? p.Item.Name : "Item",
                    p.CreatedAt
                ))
                .ToListAsync(ct);

            var recentActivities = orderHistories
                .Concat(stockLogs)
                .Concat(priceLogs)
                .OrderByDescending(a => a.Timestamp)
                .Take(limit)
                .ToList();

            var report = new StaffActivityReportDto(staffMembers, recentActivities);
            return JsonModel<StaffActivityReportDto>.Success(report, "Staff activity audit stream generated successfully.");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error generating staff activity report.");
            return JsonModel<StaffActivityReportDto>.Error("Failed to fetch staff activity logs.", 500);
        }
    }
}
