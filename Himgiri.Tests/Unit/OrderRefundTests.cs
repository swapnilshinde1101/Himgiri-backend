using System;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Data.Transactions;
using Himgiri.Infrastructure.Repositories;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

/// <summary>
/// Covers OrderService.ProcessRefundAsync's two guards: refunds require a successfully-paid
/// order (you can't refund money that was never collected), and an already-refunded order
/// can't be refunded again (prevents duplicate audit history / RefundReason overwrite).
/// </summary>
public class OrderRefundTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly OrderService _orderService;

    public OrderRefundTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        var orderRepo = new OrderRepository(_db);
        var unitOfWork = new UnitOfWork(_db, NullLogger<UnitOfWork>.Instance);

        _orderService = new OrderService(
            orderRepo: orderRepo,
            itemRepo: null!,
            gradeRepo: null!,
            unitOfWork: unitOfWork,
            db: _db,
            taxService: new TaxService(),
            excelService: null!,
            csvService: null!);
    }

    private async Task<Order> SeedOrderAsync(OrderStatus status, PaymentStatus paymentStatus, int stockQty = 10)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Test Notebook",
            Price = 40,
            Mrp = 45,
            CategoryId = Guid.NewGuid(),
            StockQty = stockQty,
            TargetQty = 100,
            IsStockInitialized = true,
            StorageStatus = StorageStatus.InStock
        };
        _db.Items.Add(item);

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
            Status = status,
            PaymentStatus = paymentStatus
        };
        order.Items.Add(new OrderItem
        {
            Id = Guid.NewGuid(),
            Order = order,
            Item = item,
            ItemId = item.Id,
            ItemName = item.Name,
            Quantity = 2,
            UnitPrice = item.Price
        });

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return order;
    }

    [Fact]
    public async Task ProcessRefundAsync_UnpaidOrder_ReturnsBadRequest()
    {
        var order = await SeedOrderAsync(OrderStatus.Pending, PaymentStatus.Pending);

        var result = await _orderService.ProcessRefundAsync(
            order.Id, new ProcessRefundRequest("Customer changed mind"), "tester");

        Assert.Equal(400, result.StatusCode);
        Assert.Contains("successful payment", result.Message, StringComparison.OrdinalIgnoreCase);

        // Read via a fresh context: ProcessRefundAsync sets IsRefunded/RefundReason on the tracked
        // entity before the rejected UpdateOrderStatusAsync call, but since that call returns before
        // ever committing, none of it is actually persisted — only visible on the stale tracked
        // instance still held by _db.
        await using var verifyContext = SqliteDbContextFactory.CreateContext(_connection);
        var reloaded = await verifyContext.Orders.FirstAsync(o => o.Id == order.Id);
        Assert.False(reloaded.IsRefunded);
        Assert.Equal(OrderStatus.Pending, reloaded.Status);
    }

    [Fact]
    public async Task ProcessRefundAsync_PaidDispatchedOrder_RefundsAndRestoresStock()
    {
        var order = await SeedOrderAsync(OrderStatus.Dispatched, PaymentStatus.Success, stockQty: 10);

        var result = await _orderService.ProcessRefundAsync(
            order.Id, new ProcessRefundRequest("Item damaged in transit"), "tester");

        Assert.Equal(200, result.StatusCode);

        var reloadedOrder = await _db.Orders.FirstAsync(o => o.Id == order.Id);
        Assert.True(reloadedOrder.IsRefunded);
        Assert.Equal(OrderStatus.Refunded, reloadedOrder.Status);

        var reloadedItem = await _db.Items.FirstAsync(i => i.Id == order.Items.First().ItemId);
        Assert.Equal(12, reloadedItem.StockQty); // 10 + 2 restored
    }

    [Fact]
    public async Task ProcessRefundAsync_AlreadyRefundedOrder_ReturnsBadRequestAndDoesNotDoubleRestoreStock()
    {
        var order = await SeedOrderAsync(OrderStatus.Dispatched, PaymentStatus.Success, stockQty: 10);

        var first = await _orderService.ProcessRefundAsync(
            order.Id, new ProcessRefundRequest("Item damaged in transit"), "tester");
        Assert.Equal(200, first.StatusCode);

        // Second refund attempt on the now-Refunded order.
        var second = await _orderService.ProcessRefundAsync(
            order.Id, new ProcessRefundRequest("Trying again"), "tester");

        Assert.Equal(400, second.StatusCode);
        Assert.Contains("already been refunded", second.Message, StringComparison.OrdinalIgnoreCase);

        // Fresh context: the second call's RefundReason="Trying again" write never committed
        // (UpdateOrderStatusAsync rejected before SaveChanges), so only the first, real refund
        // is actually persisted.
        await using var verifyContext = SqliteDbContextFactory.CreateContext(_connection);
        var reloadedItem = await verifyContext.Items.FirstAsync(i => i.Id == order.Items.First().ItemId);
        Assert.Equal(12, reloadedItem.StockQty); // still 10 + 2, not double-restored to 14

        var reloadedOrder = await verifyContext.Orders.FirstAsync(o => o.Id == order.Id);
        Assert.Equal("Item damaged in transit", reloadedOrder.RefundReason); // original reason preserved
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
