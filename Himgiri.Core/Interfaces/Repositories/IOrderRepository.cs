using Himgiri.Core.Entities;
using Himgiri.Core.Models;
using Himgiri.Core.DTOs;

namespace Himgiri.Core.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<(List<Order> Items, int TotalCount)> GetPagedAsync(OrderQueryRequest request, CancellationToken ct = default);
    void Add(Order order);
    void Update(Order order);
    void AddStatusHistory(OrderStatusHistory history);
    Task<List<OrderStatusHistory>> GetStatusHistoryAsync(Guid orderId, CancellationToken ct = default);
    Task<List<Order>> GetOrdersByCustomerMobileAsync(string mobile, CancellationToken ct = default);
    Task<List<CustomerSummaryDto>> GetUniqueCustomersAsync(CancellationToken ct = default);
    Task<VendorSettings?> GetVendorSettingsAsync(CancellationToken ct = default);
}
