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
    decimal? PurchasePrice,
    decimal Mrp,
    StorageStatus StorageStatus,
    int StockQty,
    int TargetQty,
    string Unit,
    bool IsStockInitialized,
    string CategoryName,
    Guid CategoryId,
    System.Collections.Generic.List<Guid> GradeIds,
    string GradeNames,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? CompletedAt
);

public record CreateItemRequest(
    string Name,
    string? Description,
    string? ImageUrl,
    decimal Price,
    decimal? PurchasePrice,
    decimal Mrp,
    StorageStatus StorageStatus,
    int StockQty,
    int TargetQty,
    string Unit,
    bool IsStockInitialized,
    Guid CategoryId,
    System.Collections.Generic.List<Guid> GradeIds,
    bool IsActive
);

public record CatalogItemDto(
    Guid Id,
    string Name,
    string? Description,
    string? ImageUrl,
    decimal Price,
    decimal Mrp,
    StorageStatus StorageStatus,
    int StockQty,
    int TargetQty,
    string Unit,
    bool IsStockInitialized,
    string CategoryName,
    Guid CategoryId,
    System.Collections.Generic.List<Guid> GradeIds,
    string GradeNames,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? CompletedAt
);

public record PriceAuditLogDto(
    Guid Id,
    Guid ItemId,
    string ItemName,
    decimal OldPrice,
    decimal NewPrice,
    decimal OldMrp,
    decimal NewMrp,
    string ChangedBy,
    string Reason,
    DateTime CreatedAt
);

public record CompletedStatsDto(
    int TotalCompletedCount,
    decimal TotalPurchaseValue,
    decimal TotalRetailValue,
    string MostCompletedCategory
);

public record DashboardStatsDto(
    int TotalItems,
    int LowStockCount,
    int OutOfStockCount,
    int TotalOrders,
    decimal RevenueToday,
    int PendingOrders
);

public record UpdateStockRequest(int AdjustmentQty, string Reason, int? LastSeenStockQty = null);

public record StockLogDto(
    Guid Id,
    Guid ItemId,
    string ItemName,
    int OldQty,
    int NewQty,
    string ChangedBy,
    string Reason,
    DateTime CreatedAt
);

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
    Guid? GradeId,
    List<OrderItemRequest> Items,
    bool IncludeDelivery
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

public record BulkInwardRequest(
    System.Collections.Generic.List<BulkInwardItemDto> Items,
    string Reason
);

public record BulkInwardItemDto(
    System.Guid ItemId,
    int QuantityToAdd
);

public record BulkStatusRequest(
    System.Collections.Generic.List<System.Guid> ItemIds,
    bool IsActive
);

public record BulkCategoryRequest(
    System.Collections.Generic.List<System.Guid> ItemIds,
    System.Guid CategoryId
);

public record CustomerSummaryDto(
    string CustomerName,
    string Mobile,
    string Email,
    string GradeName,
    int TotalOrders,
    decimal TotalSpent,
    System.DateTime LastOrderDate
);

// ── School Kits DTOs ──
public record SchoolKitDto(
    System.Guid Id,
    string Name,
    string? Description,
    System.Guid GradeId,
    string GradeName,
    bool IsActive,
    System.Collections.Generic.List<SchoolKitItemDto> Items,
    System.DateTime CreatedAt
);

public record SchoolKitItemDto(
    System.Guid ItemId,
    string ItemName,
    decimal Price,
    decimal Mrp,
    int Quantity,
    string CategoryName,
    string Unit,
    string? ImageUrl,
    StorageStatus StorageStatus
);

public record CreateSchoolKitRequest(
    string Name,
    string? Description,
    System.Guid GradeId,
    bool IsActive,
    System.Collections.Generic.List<CreateSchoolKitItemRequest> Items
);

public record CreateSchoolKitItemRequest(
    System.Guid ItemId,
    int Quantity
);

