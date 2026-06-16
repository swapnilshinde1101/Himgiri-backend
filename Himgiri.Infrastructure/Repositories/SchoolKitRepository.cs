using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Repositories;

public class SchoolKitRepository : ISchoolKitRepository
{
    private readonly HimgiriDbContext _db;

    public SchoolKitRepository(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task<SchoolKit?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.SchoolKits
            .Include(sk => sk.Grade)
            .Include(sk => sk.KitItems)
                .ThenInclude(ski => ski.Item)
                    .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(sk => sk.Id == id && !sk.IsDeleted, ct);
    }

    public async Task<List<SchoolKit>> GetByGradeIdAsync(Guid gradeId, CancellationToken ct = default)
    {
        return await _db.SchoolKits
            .Include(sk => sk.Grade)
            .Include(sk => sk.KitItems)
                .ThenInclude(ski => ski.Item)
                    .ThenInclude(i => i.Category)
            .Where(sk => sk.GradeId == gradeId && sk.IsActive && !sk.IsDeleted)
            .ToListAsync(ct);
    }

    public async Task<(List<SchoolKit> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        var query = _db.SchoolKits
            .Include(sk => sk.Grade)
            .Include(sk => sk.KitItems)
                .ThenInclude(ski => ski.Item)
                    .ThenInclude(i => i.Category)
            .Where(sk => !sk.IsDeleted);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var term = request.SearchTerm.Trim().ToLower();
            query = query.Where(sk => 
                sk.Name.ToLower().Contains(term) || 
                (sk.Description != null && sk.Description.ToLower().Contains(term))
            );
        }

        if (request.GradeId.HasValue)
        {
            query = query.Where(sk => sk.GradeId == request.GradeId.Value);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(sk => sk.IsActive == request.IsActive.Value);
        }

        var total = await query.CountAsync(ct);

        var isDesc = string.Equals(request.SortDirection, "DESC", StringComparison.OrdinalIgnoreCase);
        query = request.SortColumn?.ToLower() switch
        {
            "name" => isDesc ? query.OrderByDescending(sk => sk.Name) : query.OrderBy(sk => sk.Name),
            _ => isDesc ? query.OrderByDescending(sk => sk.CreatedAt) : query.OrderBy(sk => sk.CreatedAt)
        };

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public void Add(SchoolKit kit)
    {
        _db.SchoolKits.Add(kit);
    }

    public void Update(SchoolKit kit)
    {
        _db.SchoolKits.Update(kit);
    }

    public void Delete(SchoolKit kit)
    {
        _db.SchoolKits.Remove(kit);
    }

    public async Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken ct = default)
    {
        return await _db.SchoolKits.AnyAsync(sk => 
            sk.Name.ToLower() == name.ToLower() && 
            sk.Id != excludeId && 
            !sk.IsDeleted, 
            ct);
    }
}
