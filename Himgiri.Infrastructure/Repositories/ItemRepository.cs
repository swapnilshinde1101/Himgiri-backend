using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Models;
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
            .Include(i => i.Grade)
            .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted, ct);
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

            // ── CALL POSTGRES FUNCTION ──
            var sql = "SELECT * FROM usp_GetItemsPaged(@p_SearchTerm, @p_SortColumn, @p_SortDirection, @p_PageNumber, @p_PageSize)";

            var spResults = await _db.SpGetItemsPagedResults
                .FromSqlRaw(sql, pSearch, pSortCol, pSortDir, pPage, pSize)
                .ToListAsync(ct);

            if (!spResults.Any())
                return (new List<Item>(), 0);

            var totalCount = spResults.First().TotalCount;

            // Map results to entities
            var items = spResults.Select(r => new Item
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                ImageUrl = r.ImageUrl,
                Price = r.Price,
                StorageStatus = (Himgiri.Core.Enums.StorageStatus)r.StorageStatus,
                StockQty = r.StockQty,
                CategoryId = r.CategoryId,
                Category = new ItemCategory { Id = r.CategoryId, Name = r.CategoryName },
                GradeId = r.GradeId,
                Grade = new Grade { Id = r.GradeId, Name = r.GradeName },
                IsActive = r.IsActive,
                CreatedAt = r.CreatedAt
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
}
