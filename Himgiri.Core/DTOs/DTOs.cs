using Himgiri.Core.Enums;

namespace Himgiri.Core.DTOs;

// ── Auth ──
public record LoginRequest(string Email, string Password);

public record LoginResponse(
    string Token,
    string Name,
    string Email,
    AdminRole Role,
    DateTime ExpiresAt
);

// ── Items ──
public record ItemDto(
    Guid Id,
    string Name,
    string? Description,
    string? ImageUrl,
    decimal Price,
    StorageStatus StorageStatus,
    int StockQty,
    string CategoryName,
    Guid CategoryId,
    string GradeName,
    Guid GradeId,
    bool IsActive
);

public record CreateItemRequest(
    string Name,
    string? Description,
    string? ImageUrl,
    decimal Price,
    StorageStatus StorageStatus,
    int StockQty,
    Guid CategoryId,
    Guid GradeId,
    bool IsActive
);

public record UpdateStockRequest(int NewQty, string Reason);

// ── Support Entities DTOs ──
public record GradeDto(
    Guid Id, 
    string Name, 
    string ShortName, 
    string Description,
    bool IsActive,
    int DisplayOrder
);
public record CategoryDto(
    Guid Id, 
    string Name, 
    string Description,
    int DisplayOrder,
    string HsnCode, 
    decimal GstPercent, 
    decimal CgstPercent, 
    decimal SgstPercent,
    bool IsTaxable,
    bool IsActive
);

// ── Orders ──
public record CreateOrderRequest(
    string CustomerName,
    string Email,
    string Mobile,
    string AddressLine1,
    string AddressLine2,
    string City,
    string Pincode,
    Guid GradeId,
    List<OrderItemRequest> Items
);

public record OrderItemRequest(Guid ItemId, int Quantity);

public record OrderSummaryDto(
    Guid Id,
    string InvoiceNumber,
    string CustomerName,
    string Mobile,
    decimal GrandTotal,
    OrderStatus Status,
    PaymentStatus PaymentStatus,
    DateTime CreatedAt
);

public record OrderDetailDto(
    Guid Id,
    string InvoiceNumber,
    string CustomerName,
    string Email,
    string Mobile,
    string AddressLine1,
    string AddressLine2,
    string City,
    string Pincode,
    string GradeName,
    decimal SubTotal,
    decimal TotalGst,
    decimal DeliveryFee,
    decimal DeliveryGst,
    decimal GrandTotal,
    OrderStatus Status,
    PaymentStatus PaymentStatus,
    string? JodoPaymentId,
    string? AdminNotes,
    DateTime CreatedAt,
    List<OrderItemDto> Items
);

public record OrderItemDto(
    string ItemName,
    string HsnCode,
    int Quantity,
    decimal UnitPrice,
    decimal GstPercent,
    decimal GstAmount,
    decimal Cgst,
    decimal Sgst,
    decimal LineTotal
);

