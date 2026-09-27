using System;
using System.Linq;
using System.Threading.Tasks;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;
using Microsoft.Data.Sqlite;
using Xunit;

namespace Himgiri.Tests.Unit;

public class ReportServiceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly ReportService _reportService;

    public ReportServiceTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        // Clear seed data to ensure isolated unit test results
        _db.PriceAuditLogs.RemoveRange(_db.PriceAuditLogs);
        _db.StockLogs.RemoveRange(_db.StockLogs);
        _db.OrderStatusHistories.RemoveRange(_db.OrderStatusHistories);
        _db.Items.RemoveRange(_db.Items);
        _db.ItemCategories.RemoveRange(_db.ItemCategories);
        _db.Grades.RemoveRange(_db.Grades);
        _db.AdminUsers.RemoveRange(_db.AdminUsers);
        _db.SaveChanges();

        _reportService = new ReportService(_db);
    }

    [Fact]
    public async Task GetAccountReportSummaryAsync_CalculatesCorrectAggregations()
    {
        // Arrange
        var grade = new Grade { Id = Guid.NewGuid(), Name = "Grade 1", DisplayOrder = 1 };
        _db.Grades.Add(grade);

        var paidOrder = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-PAID-001",
            CustomerName = "Parent Alice",
            Email = "alice@example.com",
            Mobile = "9876543210",
            AddressLine1 = "123 Main St",
            City = "Pune",
            Pincode = "411057",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.IntraState,
            SubTotal = 1000m,
            TotalGst = 180m,
            GrandTotal = 1180m,
            GradeId = grade.Id,
            Status = OrderStatus.Confirmed,
            PaymentStatus = PaymentStatus.Success,
            CreatedAt = DateTime.UtcNow
        };

        var pendingOrder = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-PENDING-002",
            CustomerName = "Parent Bob",
            Email = "bob@example.com",
            Mobile = "9876543211",
            AddressLine1 = "456 Side St",
            City = "Pune",
            Pincode = "411057",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.IntraState,
            SubTotal = 500m,
            TotalGst = 90m,
            GrandTotal = 590m,
            GradeId = grade.Id,
            Status = OrderStatus.Pending,
            PaymentStatus = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        var refundedOrder = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-REFUND-003",
            CustomerName = "Parent Charlie",
            Email = "charlie@example.com",
            Mobile = "9876543212",
            AddressLine1 = "789 Park Rd",
            City = "Pune",
            Pincode = "411057",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.IntraState,
            SubTotal = 200m,
            TotalGst = 36m,
            GrandTotal = 236m,
            GradeId = grade.Id,
            Status = OrderStatus.Refunded,
            PaymentStatus = PaymentStatus.Success,
            IsRefunded = true,
            CreatedAt = DateTime.UtcNow
        };

        _db.Orders.AddRange(paidOrder, pendingOrder, refundedOrder);
        await _db.SaveChangesAsync();

        // Act
        var result = await _reportService.GetAccountReportSummaryAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);

        var data = result.Data;
        Assert.Equal(1180m, data.TotalPaidSales);
        Assert.Equal(1, data.TotalPaidOrdersCount);
        Assert.Equal(180m, data.TotalGstCollected);
        Assert.Equal(90m, data.TotalCgst);
        Assert.Equal(90m, data.TotalSgst);
        Assert.Equal(1000m, data.TotalNetSales);
        Assert.Equal(590m, data.UnpaidReceivables);
        Assert.Equal(1, data.PendingOrdersCount);
        Assert.Equal(236m, data.TotalRefunded);
        Assert.Equal(1, data.RefundedOrdersCount);
        Assert.Single(data.GradeSales);
        Assert.Equal("Grade 1", data.GradeSales[0].GradeName);
        Assert.Equal(1180m, data.GradeSales[0].TotalSales);
    }

    [Fact]
    public async Task GetAccountReportSummaryAsync_InterStateOrder_AttributesGstToIgstNotCgstSgst()
    {
        // Regression test: an inter-state order's GST must show up entirely as IGST, never split into
        // CGST/SGST — that split only applies to intra-state orders.
        var intraOrder = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-INTRA-001",
            CustomerName = "Parent Intra",
            Email = "intra@example.com",
            Mobile = "9876543220",
            AddressLine1 = "1 Local St",
            City = "Pune",
            Pincode = "411057",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.IntraState,
            SubTotal = 1000m,
            TotalGst = 180m,
            GrandTotal = 1180m,
            Status = OrderStatus.Confirmed,
            PaymentStatus = PaymentStatus.Success,
            CreatedAt = DateTime.UtcNow
        };

        var interOrder = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-INTER-001",
            CustomerName = "Parent Inter",
            Email = "inter@example.com",
            Mobile = "9876543221",
            AddressLine1 = "1 Distant St",
            City = "Mumbai",
            Pincode = "400001",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.InterState,
            SubTotal = 1000m,
            TotalGst = 180m,
            GrandTotal = 1180m,
            Status = OrderStatus.Confirmed,
            PaymentStatus = PaymentStatus.Success,
            CreatedAt = DateTime.UtcNow
        };

        _db.Orders.AddRange(intraOrder, interOrder);
        await _db.SaveChangesAsync();

        var result = await _reportService.GetAccountReportSummaryAsync();

        Assert.Equal(200, result.StatusCode);
        var data = result.Data!;

        Assert.Equal(360m, data.TotalGstCollected); // 180 + 180
        Assert.Equal(90m, data.TotalCgst);           // only from the intra-state order
        Assert.Equal(90m, data.TotalSgst);           // only from the intra-state order
        Assert.Equal(180m, data.TotalIgst);          // only from the inter-state order
    }

    [Fact]
    public async Task GetInventoryValuationReportAsync_ComputesAccurateValuationAndMargins()
    {
        // Arrange
        var gstRate = new GstRate { Id = Guid.NewGuid(), Name = "GST 18%", Rate = 18m };
        _db.GstRates.Add(gstRate);

        var category = new ItemCategory { Id = Guid.NewGuid(), Name = "Textbooks", DefaultGstRateId = gstRate.Id };
        _db.ItemCategories.Add(category);

        var item1 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Math Workbook",
            CategoryId = category.Id,
            StockQty = 20,
            PurchasePrice = 50m,
            Price = 80m,
            Mrp = 100m,
            GstRateId = gstRate.Id,
            LowStockThreshold = 10,
            StorageStatus = StorageStatus.InStock,
            IsStockInitialized = true,
            IsDeleted = false
        };

        var item2 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "English Reader",
            CategoryId = category.Id,
            StockQty = 5,
            PurchasePrice = 40m,
            Price = 70m,
            Mrp = 80m,
            GstRateId = gstRate.Id,
            LowStockThreshold = 10,
            StorageStatus = StorageStatus.InStock,
            IsStockInitialized = true,
            IsDeleted = false
        };

        var item3 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Science Notebook",
            CategoryId = category.Id,
            StockQty = 0,
            PurchasePrice = 20m,
            Price = 35m,
            Mrp = 40m,
            GstRateId = gstRate.Id,
            LowStockThreshold = 10,
            StorageStatus = StorageStatus.InStock,
            IsStockInitialized = true,
            IsDeleted = false
        };

        _db.Items.AddRange(item1, item2, item3);
        await _db.SaveChangesAsync();

        // Act
        var result = await _reportService.GetInventoryValuationReportAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);

        var data = result.Data;
        Assert.Equal(3, data.TotalItemsCount);
        Assert.Equal(25, data.TotalStockQty); // 20 + 5 + 0

        // Purchase value: (20 * 50) + (5 * 40) + (0 * 20) = 1000 + 200 = 1200
        Assert.Equal(1200m, data.TotalPurchaseValue);

        // Retail value (MRP): (20 * 100) + (5 * 80) + (0 * 40) = 2000 + 400 = 2400
        Assert.Equal(2400m, data.TotalRetailValue);

        // Margin: 2400 - 1200 = 1200
        Assert.Equal(1200m, data.TotalPotentialMargin);

        // Low stock: item2 has qty 5 (< 10 and > 0)
        Assert.Equal(1, data.LowStockCount);

        // Out of stock: item3 has qty 0
        Assert.Equal(1, data.OutOfStockCount);

        Assert.Single(data.CategoryBreakdown);
        Assert.Equal("Textbooks", data.CategoryBreakdown[0].CategoryName);
        Assert.Equal(2400m, data.CategoryBreakdown[0].TotalRetailValue);
    }

    [Fact]
    public async Task GetStaffActivityReportAsync_ReturnsChronologicalAuditTrail()
    {
        // Arrange
        var user = new AdminUser
        {
            Id = Guid.NewGuid(),
            Name = "Admin User",
            Email = "admin@example.com",
            Role = AdminRole.SuperAdmin,
            IsActive = true,
            LastLoginAt = DateTime.UtcNow
        };
        _db.AdminUsers.Add(user);

        var order = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-LOG-001",
            CustomerName = "Parent David",
            Email = "david@example.com",
            Mobile = "9876543213",
            AddressLine1 = "Test Address",
            City = "Pune",
            Pincode = "411057",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.IntraState,
            Status = OrderStatus.Dispatched,
            PaymentStatus = PaymentStatus.Success
        };
        _db.Orders.Add(order);

        var history = new OrderStatusHistory
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            FromStatus = OrderStatus.Packed,
            ToStatus = OrderStatus.Dispatched,
            ChangedBy = "Admin User",
            Note = "Handed to courier",
            CreatedAt = DateTime.UtcNow.AddMinutes(-5)
        };
        _db.OrderStatusHistories.Add(history);

        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = "School Bag",
            Price = 500m,
            Mrp = 600m
        };
        _db.Items.Add(item);

        var stockLog = new StockLog
        {
            Id = Guid.NewGuid(),
            ItemId = item.Id,
            OldQty = 10,
            NewQty = 50,
            ChangedBy = "Admin User",
            Reason = "Inward Shipment",
            Note = "Vendor delivery",
            CreatedAt = DateTime.UtcNow.AddMinutes(-10)
        };
        _db.StockLogs.Add(stockLog);

        await _db.SaveChangesAsync();

        // Act
        var result = await _reportService.GetStaffActivityReportAsync(limit: 20);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);

        var data = result.Data;
        Assert.Single(data.StaffMembers);
        Assert.Equal("Admin User", data.StaffMembers[0].Name);

        Assert.Equal(2, data.RecentActivities.Count);
        // Latest first
        Assert.Equal("Order Status: Dispatched", data.RecentActivities[0].ActionType);
        Assert.Equal("Stock Level Adjusted", data.RecentActivities[1].ActionType);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
