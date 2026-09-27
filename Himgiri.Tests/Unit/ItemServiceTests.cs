using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Data.Transactions;
using Himgiri.Infrastructure.Repositories;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

/// <summary>
/// Covers ItemService.UpdateItemAsync's handling of StockQty. The general Edit Item form
/// doesn't let admins type a new stock number directly (the frontend resubmits whatever
/// snapshot it last loaded), so this must never treat request.StockQty as authoritative —
/// otherwise editing something unrelated (e.g. description) while stock changes concurrently
/// via real sales/adjustments would silently revert those changes.
/// </summary>
public class ItemServiceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly ItemService _itemService;

    public ItemServiceTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        var itemRepo = new ItemRepository(_db);
        var categoryRepo = new CategoryRepository(_db);
        var gstRateRepo = new GstRateRepository(_db);
        var unitOfWork = new UnitOfWork(_db, Microsoft.Extensions.Logging.Abstractions.NullLogger<UnitOfWork>.Instance);

        _itemService = new ItemService(itemRepo, categoryRepo, gstRateRepo, unitOfWork);
    }

    private async Task<(ItemCategory category, GstRate gstRate)> SeedCategoryWithGstAsync()
    {
        var gstRate = new GstRate
        {
            Id = Guid.NewGuid(),
            Name = "GST 18%",
            HsnCode = "4901",
            Rate = 18m,
            Cgst = 9m,
            Sgst = 9m,
            Igst = 18m,
            IsActive = true
        };
        _db.GstRates.Add(gstRate);

        var category = new ItemCategory
        {
            Id = Guid.NewGuid(),
            Name = "Textbooks",
            DefaultGstRateId = gstRate.Id
        };
        _db.ItemCategories.Add(category);

        await _db.SaveChangesAsync();
        return (category, gstRate);
    }

    [Fact]
    public async Task UpdateItemAsync_DoesNotOverwriteStockQty_EvenWhenRequestSendsStaleValue()
    {
        var (category, _) = await SeedCategoryWithGstAsync();

        // Item's real, current stock is 47 — e.g. it was 50 when the admin's item list was
        // fetched, but 3 units have since sold via real customer orders.
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Math Workbook",
            Description = "Original description",
            CategoryId = category.Id,
            Price = 80m,
            Mrp = 100m,
            StockQty = 47,
            TargetQty = 100,
            Unit = "Pieces (Pcs)",
            StorageStatus = StorageStatus.InStock,
            IsActive = true,
            IsStockInitialized = true
        };
        _db.Items.Add(item);
        await _db.SaveChangesAsync();

        // Admin is only editing the description, but the Edit Item form resubmits the stale
        // StockQty=50 snapshot it loaded earlier.
        var request = new CreateItemRequest(
            Name: "Math Workbook",
            Description: "Updated description",
            ImageUrl: null,
            Price: 80m,
            PurchasePrice: null,
            Mrp: 100m,
            StorageStatus: StorageStatus.InStock,
            StockQty: 50,
            TargetQty: 100,
            Unit: "Pieces (Pcs)",
            IsStockInitialized: true,
            CategoryId: category.Id,
            GradeIds: new List<Guid>(),
            IsActive: true,
            GstRateId: null,
            LowStockThreshold: null
        );

        var result = await _itemService.UpdateItemAsync(item.Id, request, "tester");

        Assert.Equal(200, result.StatusCode);

        var reloaded = await _db.Items.FirstAsync(i => i.Id == item.Id);
        Assert.Equal(47, reloaded.StockQty); // real stock preserved, NOT reverted to the stale 50
        Assert.Equal("Updated description", reloaded.Description);

        // No stale/misleading StockLog should be written for this non-change.
        var stockLogCount = await _db.StockLogs.CountAsync(l => l.ItemId == item.Id);
        Assert.Equal(0, stockLogCount);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
