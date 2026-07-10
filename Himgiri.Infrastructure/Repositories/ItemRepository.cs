using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Models;
using Himgiri.Core.DTOs;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Himgiri.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly HimgiriDbContext _db;

    public ItemRepository(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task<Item?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Items
            .Include(i => i.Category)
                .ThenInclude(c => c.DefaultGstRate)
            .Include(i => i.GstRate)
            .Include(i => i.ItemGrades)
                .ThenInclude(ig => ig.Grade)
            .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted, ct);
    }

    public async Task<List<Item>> GetByIdsAsync(List<Guid> ids, CancellationToken ct = default)
    {
        return await _db.Items
            .Include(i => i.Category)
                .ThenInclude(c => c.DefaultGstRate)
            .Include(i => i.GstRate)
            .Include(i => i.ItemGrades)
                .ThenInclude(ig => ig.Grade)
            .Where(i => ids.Contains(i.Id) && !i.IsDeleted)
            .ToListAsync(ct);
    }

    public async Task<(List<Item> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        try 
        {
            // ── DEFINE PARAMETERS (Explicit NpgsqlParameters for reliability) ──
            var pSearch = new NpgsqlParameter("p_SearchTerm", (object?)request.SearchTerm ?? DBNull.Value);
            var pSortCol = new NpgsqlParameter("p_SortColumn", (object?)request.SortColumn ?? "name");
            var pSortDir = new NpgsqlParameter("p_SortDirection", (object?)request.SortDirection ?? "ASC");
            var pPage = new NpgsqlParameter("p_PageNumber", request.PageNumber);
            var pSize = new NpgsqlParameter("p_PageSize", request.PageSize);
            var pOnlyInitialized = new NpgsqlParameter("p_OnlyInitialized", request.OnlyInitializedStock);
            var pCategoryId = new NpgsqlParameter("p_CategoryId", (object?)request.CategoryId ?? DBNull.Value);
            var pGradeId = new NpgsqlParameter("p_GradeId", (object?)request.GradeId ?? DBNull.Value);
            var pIsActive = new NpgsqlParameter("p_IsActive", (object?)request.IsActive ?? DBNull.Value);
            var pStartDate = new NpgsqlParameter("p_StartDate", (object?)request.StartDate ?? DBNull.Value);
            var pEndDate = new NpgsqlParameter("p_EndDate", (object?)request.EndDate ?? DBNull.Value);
            var pStockStatus = new NpgsqlParameter("p_StockStatus", (object?)request.StockStatus ?? DBNull.Value);
            var pIsCompleted = new NpgsqlParameter("p_IsCompleted", (object?)request.IsCompleted ?? DBNull.Value);

            // ── CALL POSTGRES FUNCTION ──
            var sql = "SELECT * FROM usp_GetItemsPaged(@p_SearchTerm, @p_SortColumn, @p_SortDirection, @p_PageNumber, @p_PageSize, @p_OnlyInitialized, @p_CategoryId, @p_GradeId, @p_IsActive, @p_StartDate, @p_EndDate, @p_StockStatus, @p_IsCompleted)";

            var spResults = await _db.SpGetItemsPagedResults
                .FromSqlRaw(sql, pSearch, pSortCol, pSortDir, pPage, pSize, pOnlyInitialized, pCategoryId, pGradeId, pIsActive, pStartDate, pEndDate, pStockStatus, pIsCompleted)
                .ToListAsync(ct);

            if (!spResults.Any())
                return (new List<Item>(), 0);

            var totalCount = spResults.First().TotalCount;

            // Map results to entities
            var items = spResults.Select(r =>
            {
                var item = new Item
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    Price = r.Price,
                    PurchasePrice = r.PurchasePrice,
                    Mrp = r.Mrp,
                    StorageStatus = (Himgiri.Core.Enums.StorageStatus)r.StorageStatus,
                    StockQty = r.StockQty,
                    TargetQty = r.TargetQty,
                    Unit = r.Unit,
                    CategoryId = r.CategoryId,
                    Category = new ItemCategory { Id = r.CategoryId, Name = r.CategoryName },
                    IsActive = r.IsActive,
                    IsStockInitialized = r.IsStockInitialized,
                    CreatedAt = r.CreatedAt,
                    CompletedAt = r.CompletedAt
                };

                if (!string.IsNullOrEmpty(r.GradeIds))
                {
                    var gradeIdList = r.GradeIds.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    var gradeNameList = r.GradeNames.Split(", ", StringSplitOptions.None);
                    for (int i = 0; i < gradeIdList.Length; i++)
                    {
                        var gId = Guid.Parse(gradeIdList[i]);
                        var gName = i < gradeNameList.Length ? gradeNameList[i] : string.Empty;
                        item.ItemGrades.Add(new ItemGrade
                        {
                            ItemId = item.Id,
                            GradeId = gId,
                            Grade = new Grade { Id = gId, Name = gName }
                        });
                    }
                }

                return item;
            }).ToList();

            return (items, totalCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Stored Procedure Execution Failed: {ex.Message}");
            throw;
        }
    }

    public void Add(Item item) => _db.Items.Add(item);
    public void Update(Item item) => _db.Items.Update(item);
    public void Delete(Item item) => _db.Items.Remove(item); // DbContext handles soft delete
    public void AddStockLog(StockLog log) => _db.StockLogs.Add(log);
    public void AddPriceAuditLog(PriceAuditLog log) => _db.PriceAuditLogs.Add(log);

    public async Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken ct = default)
    {
        return await _db.Items.AnyAsync(i => 
            i.Name.ToLower() == name.ToLower() && 
            i.Id != excludeId && 
            !i.IsDeleted, 
            ct);
    }

    public async Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(term)) return new List<string>();

        return await _db.Items
            .Where(i => !i.IsDeleted && i.Name.ToLower().Contains(term.ToLower()))
            .Select(i => i.Name)
            .Distinct()
            .Take(10)
            .ToListAsync(ct);
    }

    public async Task<CompletedStatsDto> GetCompletedStatsAsync(CancellationToken ct = default)
    {
        var query = _db.Items
            .Include(i => i.Category)
            .Where(i => !i.IsDeleted && i.IsStockInitialized && i.StockQty == i.TargetQty);

        var totalCount = await query.CountAsync(ct);
        var totalPurchaseValue = await query.SumAsync(i => (i.PurchasePrice ?? 0) * i.TargetQty, ct);
        var totalRetailValue = await query.SumAsync(i => i.Price * i.TargetQty, ct);

        var mostCompletedCategory = await query
            .GroupBy(i => i.Category.Name)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefaultAsync(ct) ?? "N/A";

        return new CompletedStatsDto(totalCount, totalPurchaseValue, totalRetailValue, mostCompletedCategory);
    }

    public async Task<DashboardStatsDto> GetDashboardStatsAsync(CancellationToken ct = default)
    {
        var totalItems = await _db.Items.CountAsync(i => !i.IsDeleted, ct);
        var lowStockCount = await _db.Items.CountAsync(i => i.StockQty < 10 && !i.IsDeleted && i.IsStockInitialized, ct);
        var outOfStockCount = await _db.Items.CountAsync(i => i.StockQty == 0 && !i.IsDeleted && i.IsStockInitialized, ct);

        var totalOrders = await _db.Orders.CountAsync(o => o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted, ct);

        var todayStart = DateTime.UtcNow.Date;
        var todayEnd = todayStart.AddDays(1);
        var revenueToday = await _db.Orders
            .Where(o => o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted && o.CreatedAt >= todayStart && o.CreatedAt < todayEnd)
            .SumAsync(o => (decimal?)o.GrandTotal, ct) ?? 0.00m;

        var pendingOrders = await _db.Orders.CountAsync(o => (o.Status == OrderStatus.Pending || o.Status == OrderStatus.Confirmed) && !o.IsDeleted, ct);

        return new DashboardStatsDto(
            TotalItems: totalItems,
            LowStockCount: lowStockCount,
            OutOfStockCount: outOfStockCount,
            TotalOrders: totalOrders,
            RevenueToday: revenueToday,
            PendingOrders: pendingOrders
        );
    }

    public async Task<(List<Item> Items, int TotalCount)> GetCatalogItemsByGradeAsync(BaseRequest request, CancellationToken ct = default)
    {
        var query = _db.Items
            .Include(i => i.Category)
            .Include(i => i.ItemGrades)
                .ThenInclude(ig => ig.Grade)
            .Where(i => i.IsActive && !i.IsDeleted);

        if (request.GradeId.HasValue && request.GradeId.Value != Guid.Empty)
        {
            query = query.Where(i => i.ItemGrades.Any(ig => ig.GradeId == request.GradeId.Value));
        }

        if (request.CategoryId.HasValue && request.CategoryId.Value != Guid.Empty)
        {
            query = query.Where(i => i.CategoryId == request.CategoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var term = request.SearchTerm.Trim();
            query = query.Where(i => 
                EF.Functions.ILike(i.Name, $"%{term}%") || 
                (i.Description != null && EF.Functions.ILike(i.Description, $"%{term}%")));
        }

        var total = await query.CountAsync(ct);

        var items = await query
            .OrderBy(i => i.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public async Task<List<PriceAuditLog>> GetPriceAuditLogsAsync(Guid itemId, CancellationToken ct = default)
    {
        return await _db.PriceAuditLogs
            .Include(pal => pal.Item)
            .Where(pal => pal.ItemId == itemId && !pal.IsDeleted)
            .OrderByDescending(pal => pal.CreatedAt)
            .ToListAsync(ct);
    }
}
