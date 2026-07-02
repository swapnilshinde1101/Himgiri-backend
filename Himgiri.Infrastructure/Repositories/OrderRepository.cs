using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Models;
using Himgiri.Core.DTOs;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly HimgiriDbContext _db;

    public OrderRepository(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Orders
            .Include(o => o.Items)
                .ThenInclude(oi => oi.Item)
            .Include(o => o.Grade)
            .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted, ct);
    }

    public async Task<(List<Order> Items, int TotalCount)> GetPagedAsync(OrderQueryRequest request, CancellationToken ct = default)
    {
        var query = _db.Orders
            .Include(o => o.Grade)
            .Where(o => !o.IsDeleted);

        // Search Term: invoice no, customer name, mobile
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var search = request.SearchTerm.Trim().ToLower();
            query = query.Where(o =>
                o.InvoiceNumber.ToLower().Contains(search) ||
                o.CustomerName.ToLower().Contains(search) ||
                o.Mobile.Contains(search)
            );
        }

        // Filters
        if (request.Status.HasValue)
        {
            query = query.Where(o => o.Status == request.Status.Value);
        }

        if (request.PaymentStatus.HasValue)
        {
            query = query.Where(o => o.PaymentStatus == request.PaymentStatus.Value);
        }

        if (request.GradeId.HasValue)
        {
            query = query.Where(o => o.GradeId == request.GradeId.Value);
        }

        if (request.StartDate.HasValue)
        {
            query = query.Where(o => o.CreatedAt >= request.StartDate.Value);
        }

        if (request.EndDate.HasValue)
        {
            query = query.Where(o => o.CreatedAt <= request.EndDate.Value);
        }

        // Sorting
        var isDesc = string.Equals(request.SortDirection, "DESC", StringComparison.OrdinalIgnoreCase);
        query = request.SortColumn?.ToLower() switch
        {
            "invoicenumber" => isDesc ? query.OrderByDescending(o => o.InvoiceNumber) : query.OrderBy(o => o.InvoiceNumber),
            "customername" => isDesc ? query.OrderByDescending(o => o.CustomerName) : query.OrderBy(o => o.CustomerName),
            "grandtotal" => isDesc ? query.OrderByDescending(o => o.GrandTotal) : query.OrderBy(o => o.GrandTotal),
            "status" => isDesc ? query.OrderByDescending(o => o.Status) : query.OrderBy(o => o.Status),
            "paymentstatus" => isDesc ? query.OrderByDescending(o => o.PaymentStatus) : query.OrderBy(o => o.PaymentStatus),
            _ => isDesc ? query.OrderByDescending(o => o.CreatedAt) : query.OrderBy(o => o.CreatedAt)
        };

        var total = await query.CountAsync(ct);
        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public void Add(Order order)
    {
        _db.Orders.Add(order);
    }

    public void Update(Order order)
    {
        _db.Orders.Update(order);
    }

    public void AddStatusHistory(OrderStatusHistory history)
    {
        _db.OrderStatusHistories.Add(history);
    }

    public async Task<List<OrderStatusHistory>> GetStatusHistoryAsync(Guid orderId, CancellationToken ct = default)
    {
        return await _db.OrderStatusHistories
            .Where(h => h.OrderId == orderId && !h.IsDeleted)
            .OrderByDescending(h => h.CreatedAt)
            .ToListAsync(ct);
    }

    public async Task<List<Order>> GetOrdersByCustomerMobileAsync(string mobile, CancellationToken ct = default)
    {
        return await _db.Orders
            .Include(o => o.Items)
            .Where(o => o.Mobile == mobile && o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync(ct);
    }

    public async Task<List<CustomerSummaryDto>> GetUniqueCustomersAsync(CancellationToken ct = default)
    {
        var customers = await _db.Orders
            .Where(o => o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted)
            .GroupBy(o => o.Mobile)
            .Select(g => new CustomerSummaryDto(
                g.OrderByDescending(o => o.CreatedAt).First().CustomerName,
                g.Key,
                g.OrderByDescending(o => o.CreatedAt).First().Email,
                g.OrderByDescending(o => o.CreatedAt).First().GradeName,
                g.Count(),
                g.Sum(o => o.GrandTotal),
                g.Max(o => o.CreatedAt)
            ))
            .OrderByDescending(c => c.LastOrderDate)
            .ToListAsync(ct);

        return customers;
    }

    public async Task<VendorSettings?> GetVendorSettingsAsync(CancellationToken ct = default)
    {
        return await _db.VendorSettings
            .FromSqlRaw("SELECT * FROM \"VendorSettings\" LIMIT 1 FOR UPDATE")
            .FirstOrDefaultAsync(ct);
    }
}
