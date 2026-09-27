using System;
using System.Collections.Generic;

namespace Himgiri.Core.DTOs;

public record GradeSalesSummaryDto(
    Guid GradeId,
    string GradeName,
    int OrderCount,
    decimal TotalSales,
    int TotalItemsCount
);

public record PaymentStatusSummaryDto(
    string PaymentStatus,
    int OrderCount,
    decimal TotalAmount
);

public record AccountReportSummaryDto(
    decimal TotalPaidSales,
    int TotalPaidOrdersCount,
    decimal UnpaidReceivables,
    int PendingOrdersCount,
    decimal TotalRefunded,
    int RefundedOrdersCount,
    decimal TotalGstCollected,
    decimal TotalCgst,
    decimal TotalSgst,
    decimal TotalIgst,
    decimal TotalNetSales,
    List<GradeSalesSummaryDto> GradeSales,
    List<PaymentStatusSummaryDto> PaymentBreakdown
);

public record CategoryValuationDto(
    Guid? CategoryId,
    string CategoryName,
    int ItemCount,
    int TotalStockQty,
    decimal TotalPurchaseValue,
    decimal TotalRetailValue,
    decimal PotentialMargin
);

public record InventoryValuationReportDto(
    int TotalItemsCount,
    int TotalStockQty,
    decimal TotalPurchaseValue,
    decimal TotalRetailValue,
    decimal TotalPotentialMargin,
    int LowStockCount,
    int OutOfStockCount,
    List<CategoryValuationDto> CategoryBreakdown
);

public record StaffUserDto(
    Guid Id,
    string Name,
    string Email,
    string Role,
    DateTime? LastLoginAt,
    bool IsActive
);

public record StaffActivityLogDto(
    string Id,
    string AdminName,
    string ActionType,
    string Details,
    string? Reference,
    DateTime Timestamp
);

public record StaffActivityReportDto(
    List<StaffUserDto> StaffMembers,
    List<StaffActivityLogDto> RecentActivities
);
