using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Xunit;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

public class InvoiceServiceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly InvoiceService _invoiceService;

    public InvoiceServiceTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();
        _invoiceService = new InvoiceService(_db);
    }

    private async Task<Order> CreateTestOrderAsync(
        string sellerGstin = "27ABCDE1234F1Z5", 
        bool isHomeDelivery = true, 
        SupplyType supplyType = SupplyType.IntraState)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-2026-0001",
            CustomerName = "Rajesh Sharma",
            Email = "rajesh.sharma@example.com",
            Mobile = "9876543210",
            AddressLine1 = "Flat 402, Sunshine Heights",
            AddressLine2 = "Baner Road",
            City = "Pune",
            Pincode = "411045",
            GradeName = "Grade 5-A",
            SellerCompanyName = "Himgiri Uniforms & Stationary Pvt Ltd",
            SellerGstin = sellerGstin,
            SellerAddress = "Shop 12, Commercial Complex, FC Road, Pune",
            SellerStateName = "Maharashtra",
            SellerGstStateCode = "27",
            CustomerStateName = "Maharashtra",
            CustomerGstStateCode = "27",
            PlaceOfSupply = "Maharashtra",
            PlaceOfSupplyCode = "27",
            SupplyType = supplyType,
            IsHomeDelivery = isHomeDelivery,
            SubTotal = 1200m,
            TotalGst = 216m,
            DeliveryFee = isHomeDelivery ? 250m : 0m,
            DeliveryGst = isHomeDelivery ? 45m : 0m,
            DeliveryCgstAmount = isHomeDelivery && supplyType == SupplyType.IntraState ? 22.50m : 0m,
            DeliverySgstAmount = isHomeDelivery && supplyType == SupplyType.IntraState ? 22.50m : 0m,
            DeliveryIgstAmount = isHomeDelivery && supplyType == SupplyType.InterState ? 45m : 0m,
            GrandTotal = isHomeDelivery ? 1711m : 1416m,
            Status = OrderStatus.Confirmed,
            PaymentStatus = PaymentStatus.Success,
            CreatedAt = DateTime.UtcNow
        };

        var item1 = new OrderItem
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            ItemId = Guid.NewGuid(),
            ItemName = "Standard School Kit (Grade 5)",
            HsnCode = "4901",
            Quantity = 1,
            UnitPrice = 800m,
            BaseAmount = 800m,
            GstPercent = 18m,
            CgstPercent = supplyType == SupplyType.IntraState ? 9m : 0m,
            SgstPercent = supplyType == SupplyType.IntraState ? 9m : 0m,
            IgstPercent = supplyType == SupplyType.InterState ? 18m : 0m,
            GstAmount = 144m,
            CgstAmount = supplyType == SupplyType.IntraState ? 72m : 0m,
            SgstAmount = supplyType == SupplyType.IntraState ? 72m : 0m,
            IgstAmount = supplyType == SupplyType.InterState ? 144m : 0m,
            LineTotal = 944m,
            IsKitItem = true
        };

        var item2 = new OrderItem
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            ItemId = Guid.NewGuid(),
            ItemName = "School Uniform Polo Shirt (Size 32)",
            HsnCode = "6109",
            Quantity = 2,
            UnitPrice = 200m,
            BaseAmount = 400m,
            GstPercent = 18m,
            CgstPercent = supplyType == SupplyType.IntraState ? 9m : 0m,
            SgstPercent = supplyType == SupplyType.IntraState ? 9m : 0m,
            IgstPercent = supplyType == SupplyType.InterState ? 18m : 0m,
            GstAmount = 72m,
            CgstAmount = supplyType == SupplyType.IntraState ? 36m : 0m,
            SgstAmount = supplyType == SupplyType.IntraState ? 36m : 0m,
            IgstAmount = supplyType == SupplyType.InterState ? 72m : 0m,
            LineTotal = 472m,
            IsKitItem = false
        };

        order.Items.Add(item1);
        order.Items.Add(item2);

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }

    [Fact]
    public async Task GenerateInvoiceAsync_OrderNotFound_Returns404()
    {
        var result = await _invoiceService.GenerateInvoiceAsync(Guid.NewGuid());
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Data);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("27GSTIN_PENDING")]
    [InlineData("PENDING")]
    [InlineData("27SHORT123")]
    public async Task GenerateInvoiceAsync_InvalidVendorGstin_BlocksWith503(string invalidGstin)
    {
        var order = await CreateTestOrderAsync(sellerGstin: invalidGstin);
        var result = await _invoiceService.GenerateInvoiceAsync(order.Id);

        Assert.Equal(503, result.StatusCode);
        Assert.Null(result.Data);
        Assert.Contains("GSTIN", result.Message);
    }

    [Fact]
    public async Task GenerateInvoiceAsync_ValidIntraStateOrder_GeneratesPdfBytesSuccessfully()
    {
        var order = await CreateTestOrderAsync(sellerGstin: "27ABCDE1234F1Z5", isHomeDelivery: true, supplyType: SupplyType.IntraState);
        var result = await _invoiceService.GenerateInvoiceAsync(order.Id);

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);
        Assert.Equal(order.InvoiceNumber, result.Data.InvoiceNumber);
        Assert.Equal("application/pdf", result.Data.ContentType);
        Assert.NotNull(result.Data.PdfContent);
        Assert.True(result.Data.PdfContent.Length > 1000); // Valid PDF size
    }

    [Fact]
    public async Task GenerateInvoiceAsync_ValidInterStateOrder_GeneratesPdfBytesSuccessfully()
    {
        var order = await CreateTestOrderAsync(sellerGstin: "27ABCDE1234F1Z5", isHomeDelivery: true, supplyType: SupplyType.InterState);
        var result = await _invoiceService.GenerateInvoiceAsync(order.Id);

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);
        Assert.True(result.Data.PdfContent.Length > 1000);
    }

    [Fact]
    public async Task GenerateDeliveryChallanAsync_OrderNotFound_Returns404()
    {
        var result = await _invoiceService.GenerateDeliveryChallanAsync(Guid.NewGuid());
        Assert.Equal(404, result.StatusCode);
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task GenerateDeliveryChallanAsync_HomeDeliveryOrder_GeneratesChallanSuccessfully()
    {
        var order = await CreateTestOrderAsync(sellerGstin: "27ABCDE1234F1Z5", isHomeDelivery: true);
        var result = await _invoiceService.GenerateDeliveryChallanAsync(order.Id);

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);
        Assert.Equal($"DC-{order.InvoiceNumber}", result.Data.ChallanNumber);
        Assert.Equal("application/pdf", result.Data.ContentType);
        Assert.NotNull(result.Data.PdfContent);
        Assert.True(result.Data.PdfContent.Length > 1000);
    }

    [Fact]
    public async Task GenerateDeliveryChallanAsync_CampusHandoverOrder_GeneratesChallanSuccessfully()
    {
        var order = await CreateTestOrderAsync(sellerGstin: "27ABCDE1234F1Z5", isHomeDelivery: false);
        var result = await _invoiceService.GenerateDeliveryChallanAsync(order.Id);

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Data);
        Assert.Equal($"DC-{order.InvoiceNumber}", result.Data.ChallanNumber);
        Assert.True(result.Data.PdfContent.Length > 1000);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
