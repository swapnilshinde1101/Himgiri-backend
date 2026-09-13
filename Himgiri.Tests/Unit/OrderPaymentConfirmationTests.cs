using System;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

public class OrderPaymentConfirmationTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly OrderService _orderService;

    public OrderPaymentConfirmationTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        // orderRepo/itemRepo/gradeRepo/unitOfWork/excelService/csvService are unused by
        // ConfirmPaymentAsync, which manages its own transaction directly via _db.
        _orderService = new OrderService(
            orderRepo: null!,
            itemRepo: null!,
            gradeRepo: null!,
            unitOfWork: null!,
            db: _db,
            taxService: new TaxService(),
            excelService: null!,
            csvService: null!);
    }

    private async Task<Order> SeedPendingOrderAsync()
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = $"HG-TEST-{Guid.NewGuid():N}".Substring(0, 20),
            CustomerName = "Test Customer",
            Email = "test@example.com",
            Mobile = "9999999999",
            AddressLine1 = "Line 1",
            City = "Pune",
            Pincode = "411057",
            SellerStateId = Guid.NewGuid(),
            CustomerStateId = Guid.NewGuid(),
            SupplyType = SupplyType.IntraState,
            SubTotal = 1000,
            TotalGst = 180,
            GrandTotal = 1180,
            Status = OrderStatus.Pending,
            PaymentStatus = PaymentStatus.Pending
        };
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }

    [Fact]
    public async Task ConfirmPaymentAsync_FirstCall_MarksOrderConfirmedAndAddsHistory()
    {
        var order = await SeedPendingOrderAsync();

        var result = await _orderService.ConfirmPaymentAsync(order.Id, "TXN-001");

        Assert.Equal(200, result.StatusCode);

        // ConfirmPaymentAsync uses ExecuteUpdateAsync, a bulk operation that writes
        // straight to the database without touching the change tracker — so _db's
        // already-tracked (stale, pre-update) order instance won't reflect it. Read
        // via a fresh context to see what actually persisted.
        await using var verifyContext = SqliteDbContextFactory.CreateContext(_connection);
        var reloaded = await verifyContext.Orders.FirstAsync(o => o.Id == order.Id);
        Assert.Equal(PaymentStatus.Success, reloaded.PaymentStatus);
        Assert.Equal(OrderStatus.Confirmed, reloaded.Status);
        Assert.Equal("TXN-001", reloaded.JodoPaymentId);

        var historyCount = await verifyContext.OrderStatusHistories.CountAsync(h => h.OrderId == order.Id);
        Assert.Equal(1, historyCount);
    }

    [Fact]
    public async Task ConfirmPaymentAsync_CalledTwice_IsIdempotent_NoDuplicateHistory()
    {
        // Regression test: Jodo (like most gateways) can retry a webhook delivery for the
        // same order. Two deliveries must not both apply, or produce duplicate confirmations.
        var order = await SeedPendingOrderAsync();

        var first = await _orderService.ConfirmPaymentAsync(order.Id, "TXN-001");
        var second = await _orderService.ConfirmPaymentAsync(order.Id, "TXN-002");

        Assert.Equal(200, first.StatusCode);
        Assert.Equal(200, second.StatusCode);
        Assert.Equal("Payment already processed.", second.Message);

        await using var verifyContext = SqliteDbContextFactory.CreateContext(_connection);
        var reloaded = await verifyContext.Orders.FirstAsync(o => o.Id == order.Id);
        Assert.Equal("TXN-001", reloaded.JodoPaymentId); // first write wins; second is a no-op

        var historyCount = await verifyContext.OrderStatusHistories.CountAsync(h => h.OrderId == order.Id);
        Assert.Equal(1, historyCount);
    }

    [Fact]
    public async Task ConfirmPaymentAsync_OrderNotFound_ReturnsNotFound()
    {
        var result = await _orderService.ConfirmPaymentAsync(Guid.NewGuid(), "TXN-XYZ");

        Assert.Equal(404, result.StatusCode);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
