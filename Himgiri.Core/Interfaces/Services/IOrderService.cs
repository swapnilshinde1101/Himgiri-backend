using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IOrderService
{
    Task<JsonModel<OrderSummaryDto>> CreateOrderAsync(CreateOrderRequest request, CancellationToken ct = default);
    Task<JsonModel<OrderDetailDto>> GetOrderByIdAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<List<OrderSummaryDto>>> GetPagedOrdersAsync(OrderQueryRequest request, CancellationToken ct = default);
    Task<JsonModel<bool>> UpdateOrderStatusAsync(Guid id, OrderStatusDto request, string changedBy, CancellationToken ct = default);
    Task<JsonModel<bool>> AddOrderNoteAsync(Guid id, AddOrderNoteRequest request, string changedBy, CancellationToken ct = default);
    Task<JsonModel<bool>> FlagStockOutAsync(Guid id, string changedBy, CancellationToken ct = default);
    Task<JsonModel<bool>> ProcessRefundAsync(Guid id, ProcessRefundRequest request, string changedBy, CancellationToken ct = default);
    Task<byte[]> ExportOrdersToCsvAsync(CancellationToken ct = default);
    Task<byte[]> ExportOrdersToExcelAsync(CancellationToken ct = default);
    Task CancelStalePendingOrdersAsync(CancellationToken ct = default);
    Task<JsonModel<List<CustomerSummaryDto>>> GetCustomersAsync(CancellationToken ct = default);
    Task<JsonModel<List<OrderSummaryDto>>> GetOrdersByCustomerAsync(string mobile, CancellationToken ct = default);
    Task<JsonModel<bool>> ConfirmPaymentAsync(Guid orderId, string transactionId, CancellationToken ct = default);
}

// Support DTO records needed for requests:
public record OrderStatusDto(Himgiri.Core.Enums.OrderStatus ToStatus, string? Note);
public record AddOrderNoteRequest(string Note);
public record ProcessRefundRequest(string Reason);
