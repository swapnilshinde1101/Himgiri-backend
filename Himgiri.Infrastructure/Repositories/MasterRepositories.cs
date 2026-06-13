using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly HimgiriDbContext _db;
    public GradeRepository(HimgiriDbContext db) => _db = db;

    public async Task<List<Grade>> GetAllAsync(CancellationToken ct = default)
        => await _db.Grades.Where(g => !g.IsDeleted).OrderBy(g => g.DisplayOrder).ToListAsync(ct);

    public async Task<(List<Grade> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        var spResults = await _db.SpGetGradesPagedResults
            .FromSqlInterpolated($"SELECT * FROM usp_GetGradesPaged({request.SearchTerm}, {request.PageNumber}, {request.PageSize})")
            .ToListAsync(ct);

        if (!spResults.Any()) return (new List<Grade>(), 0);

        var total = spResults.First().TotalCount;
        var items = spResults.Select(r => new Grade {
            Id = r.Id, 
            Name = r.Name, 
            ShortName = r.ShortName, 
            Description = r.Description ?? string.Empty,
            DisplayOrder = r.DisplayOrder, 
            IsActive = r.IsActive,
            CreatedAt = r.CreatedAt
        }).ToList();

        return (items, total);
    }

    public async Task<Grade?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.Grades.FirstOrDefaultAsync(g => g.Id == id && !g.IsDeleted, ct);

    public void Add(Grade grade) => _db.Grades.Add(grade);
    public void Update(Grade grade) => _db.Grades.Update(grade);
    public void Delete(Grade grade) => _db.Grades.Remove(grade);

    public async Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(term)) return new List<string>();
        return await _db.Grades
            .Where(g => !g.IsDeleted && g.Name.ToLower().Contains(term.ToLower()))
            .Select(g => g.Name)
            .Distinct().Take(10).ToListAsync(ct);
    }

    public async Task<bool> HasLinkedItemsAsync(Guid id, CancellationToken ct = default)
        => await _db.ItemGrades.AnyAsync(ig => ig.GradeId == id && !ig.Item.IsDeleted, ct);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly HimgiriDbContext _db;
    public CategoryRepository(HimgiriDbContext db) => _db = db;

    public async Task<List<ItemCategory>> GetAllAsync(CancellationToken ct = default)
        => await _db.ItemCategories
            .Where(c => !c.IsDeleted)
            .OrderBy(c => c.DisplayOrder)
            .ThenBy(c => c.Name)
            .ToListAsync(ct);

    public async Task<(List<ItemCategory> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        var spResults = await _db.SpGetCategoriesPagedResults
            .FromSqlInterpolated($"SELECT * FROM usp_GetCategoriesPaged({request.SearchTerm}, {request.PageNumber}, {request.PageSize})")
            .ToListAsync(ct);

        if (!spResults.Any()) return (new List<ItemCategory>(), 0);

        var total = spResults.First().TotalCount;
        var items = spResults.Select(r => new ItemCategory {
            Id = r.Id, 
            Name = r.Name, 
            Description = r.Description ?? string.Empty,
            IsActive = r.IsActive,
            DisplayOrder = r.DisplayOrder,
            HsnCode = r.HsnCode, 
            GstPercent = r.GstPercent, 
            CgstPercent = r.CgstPercent,
            SgstPercent = r.SgstPercent,
            IsTaxable = r.IsTaxable,
            CreatedAt = r.CreatedAt
        }).ToList();

        return (items, total);
    }

    public async Task<ItemCategory?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.ItemCategories
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, ct);

    public void Add(ItemCategory category) => _db.ItemCategories.Add(category);
    public void Update(ItemCategory category) => _db.ItemCategories.Update(category);
    public void Delete(ItemCategory category) => _db.ItemCategories.Remove(category);

    public async Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(term)) return new List<string>();
        return await _db.ItemCategories
            .Where(c => !c.IsDeleted && c.Name.ToLower().Contains(term.ToLower()))
            .Select(c => c.Name)
            .Distinct().Take(10).ToListAsync(ct);
    }

    public async Task<bool> HasLinkedItemsAsync(Guid id, CancellationToken ct = default)
        => await _db.Items.AnyAsync(i => i.CategoryId == id && !i.IsDeleted, ct);
}
