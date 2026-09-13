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
/// Covers OrderService.UpdateOrderStatusAsync's dispatch-triggered stock deduction.
/// Item.StockQty carries [ConcurrencyCheck], so a genuine concurrent write to the same
/// item (e.g. two admins dispatching different orders sharing an item at once) must be
/// detected by EF and surfaced as a clean 409 — not a raw unhandled 500.
/// </summary>
public class OrderDispatchConcurrencyTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly OrderService _orderService;

    public OrderDispatchConcurrencyTests()
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

    private async Task<(Order order, Item item)> SeedPackedOrderWithStockAsync(int stockQty)
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
            Status = OrderStatus.Packed,
            PaymentStatus = PaymentStatus.Success
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

        return (order, item);
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_PackedToDispatched_DeductsStock()
    {
        var (order, item) = await SeedPackedOrderWithStockAsync(stockQty: 10);

        var result = await _orderService.UpdateOrderStatusAsync(
            order.Id, new OrderStatusDto(OrderStatus.Dispatched, null), "tester");

        Assert.Equal(200, result.StatusCode);

        var reloadedItem = await _db.Items.FirstAsync(i => i.Id == item.Id);
        Assert.Equal(8, reloadedItem.StockQty); // 10 - 2 (order quantity)

        var reloadedOrder = await _db.Orders.FirstAsync(o => o.Id == order.Id);
        Assert.Equal(OrderStatus.Dispatched, reloadedOrder.Status);
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_ConcurrentStockWrite_ReturnsCleanConflictInsteadOfThrowing()
    {
        var (order, item) = await SeedPackedOrderWithStockAsync(stockQty: 10);

        // Simulate a second admin concurrently adjusting the same item's stock via a
        // separate DbContext, after this test's context already has the item tracked
        // (from seeding) at StockQty = 10.
        await using (var otherConnectionContext = SqliteDbContextFactory.CreateContext(_connection))
        {
            var concurrentItem = await otherConnectionContext.Items.FirstAsync(i => i.Id == item.Id);
            concurrentItem.StockQty = 5;
            await otherConnectionContext.SaveChangesAsync();
        }

        // This test's context still holds the item tracked with original StockQty = 10,
        // so its update ("10 - 2 = 8") is generated as UPDATE ... WHERE StockQty = 10,
        // which no longer matches the row (now 5) and must surface as a clean 409.
        var result = await _orderService.UpdateOrderStatusAsync(
            order.Id, new OrderStatusDto(OrderStatus.Dispatched, null), "tester");

        Assert.Equal(409, result.StatusCode);
        Assert.Contains("concurrently", result.Message, StringComparison.OrdinalIgnoreCase);

        // Read via a fresh context — _db still holds the failed in-memory write (8) on
        // its tracked entity, since a failed SaveChanges doesn't roll back local state.
        // What matters is what actually persisted: the other admin's write, untouched.
        await using var verifyContext = SqliteDbContextFactory.CreateContext(_connection);
        var persistedItem = await verifyContext.Items.FirstAsync(i => i.Id == item.Id);
        Assert.Equal(5, persistedItem.StockQty);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
