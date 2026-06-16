using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Services;

public class SchoolKitService : ISchoolKitService
{
    private readonly ISchoolKitRepository _schoolKitRepo;
    private readonly IGradeRepository _gradeRepo;
    private readonly IItemRepository _itemRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HimgiriDbContext _db;

    public SchoolKitService(
        ISchoolKitRepository schoolKitRepo,
        IGradeRepository gradeRepo,
        IItemRepository itemRepo,
        IUnitOfWork unitOfWork,
        HimgiriDbContext db)
    {
        _schoolKitRepo = schoolKitRepo;
        _gradeRepo = gradeRepo;
        _itemRepo = itemRepo;
        _unitOfWork = unitOfWork;
        _db = db;
    }

    public async Task<JsonModel<SchoolKitDto>> CreateKitAsync(CreateSchoolKitRequest request, CancellationToken ct = default)
    {
        // ── 1. Validate Input Fields ──
        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Trim().Length < 3 || request.Name.Trim().Length > 200)
        {
            return JsonModel<SchoolKitDto>.Error("Kit Name is required and must be between 3 and 200 characters.", 400);
        }

        if (await _schoolKitRepo.ExistsByNameAsync(request.Name.Trim(), null, ct))
        {
            return JsonModel<SchoolKitDto>.Error($"A School Kit named '{request.Name}' already exists.", 400);
        }

        var grade = await _gradeRepo.GetByIdAsync(request.GradeId, ct);
        if (grade == null)
        {
            return JsonModel<SchoolKitDto>.Error("The selected Grade does not exist.", 404);
        }

        if (!grade.IsActive)
        {
            return JsonModel<SchoolKitDto>.Error("The selected Grade is currently inactive.", 400);
        }

        // Check for grade name mismatches in kit name
        var allGrades = await _db.Grades.Where(g => !g.IsDeleted).ToListAsync(ct);
        var otherGrades = allGrades.Where(g => g.Id != request.GradeId).ToList();

        foreach (var otherGrade in otherGrades)
        {
            if (!string.IsNullOrEmpty(otherGrade.Name))
            {
                var pattern = $@"\b{System.Text.RegularExpressions.Regex.Escape(otherGrade.Name)}\b";
                if (System.Text.RegularExpressions.Regex.IsMatch(request.Name, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return JsonModel<SchoolKitDto>.Error($"Kit Name cannot reference a different Grade ('{otherGrade.Name}').", 400);
                }
            }

            if (!string.IsNullOrEmpty(otherGrade.ShortName))
            {
                var pattern = $@"\b{System.Text.RegularExpressions.Regex.Escape(otherGrade.ShortName)}\b";
                if (System.Text.RegularExpressions.Regex.IsMatch(request.Name, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return JsonModel<SchoolKitDto>.Error($"Kit Name cannot reference a different Grade ('{otherGrade.ShortName}').", 400);
                }
            }
        }

        if (request.IsActive)
        {
            var hasActiveKit = await _db.SchoolKits.AnyAsync(sk => 
                sk.GradeId == request.GradeId && 
                sk.IsActive && 
                !sk.IsDeleted, 
                ct);
            if (hasActiveKit)
            {
                return JsonModel<SchoolKitDto>.Error("An active School Kit already exists for this Grade.", 400);
            }
        }

        if (request.Items == null || !request.Items.Any())
        {
            return JsonModel<SchoolKitDto>.Error("A School Kit must contain at least one item.", 400);
        }

        // Group duplicate item requests in the kit payload
        var groupedItems = request.Items
            .GroupBy(i => i.ItemId)
            .Select(g => new CreateSchoolKitItemRequest(g.Key, g.Sum(i => i.Quantity)))
            .ToList();

        var itemIds = groupedItems.Select(i => i.ItemId).ToList();
        var dbItems = await _itemRepo.GetByIdsAsync(itemIds, ct);

        // Verify all items exist, are active, and belong to the selected grade
        foreach (var reqItem in groupedItems)
        {
            var dbItem = dbItems.FirstOrDefault(i => i.Id == reqItem.ItemId);
            if (dbItem == null)
            {
                return JsonModel<SchoolKitDto>.Error($"Item with ID '{reqItem.ItemId}' not found.", 404);
            }

            if (!dbItem.IsActive)
            {
                return JsonModel<SchoolKitDto>.Error($"Item '{dbItem.Name}' is currently inactive.", 400);
            }

            if (!dbItem.ItemGrades.Any(ig => ig.GradeId == request.GradeId))
            {
                return JsonModel<SchoolKitDto>.Error($"Item '{dbItem.Name}' does not belong to the selected Grade '{grade.Name}'.", 400);
            }

            if (reqItem.Quantity <= 0)
            {
                return JsonModel<SchoolKitDto>.Error($"Quantity for item '{dbItem.Name}' must be greater than zero.", 400);
            }
        }

        // ── 2. Create Kit within a Database Transaction ──
        await _unitOfWork.BeginTransactionAsync(ct);
        try
        {
            var kit = new SchoolKit
            {
                Id = Guid.NewGuid(),
                Name = request.Name.Trim(),
                Description = request.Description?.Trim(),
                GradeId = request.GradeId,
                IsActive = request.IsActive
            };

            foreach (var reqItem in groupedItems)
            {
                kit.KitItems.Add(new SchoolKitItem
                {
                    SchoolKitId = kit.Id,
                    ItemId = reqItem.ItemId,
                    Quantity = reqItem.Quantity
                });
            }

            _schoolKitRepo.Add(kit);

            await _unitOfWork.CommitTransactionAsync(ct);

            // Re-load to populate full navigation properties for DTO mapping
            var loadedKit = await _schoolKitRepo.GetByIdAsync(kit.Id, ct);
            return JsonModel<SchoolKitDto>.Success(MapToDto(loadedKit!), "School Kit created successfully.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(ct);
            return JsonModel<SchoolKitDto>.Error($"Failed to create School Kit: {ex.Message}");
        }
    }

    public async Task<JsonModel<SchoolKitDto>> GetKitByIdAsync(Guid id, CancellationToken ct = default)
    {
        var kit = await _schoolKitRepo.GetByIdAsync(id, ct);
        if (kit == null)
        {
            return JsonModel<SchoolKitDto>.Error("School Kit not found.", 404);
        }

        return JsonModel<SchoolKitDto>.Success(MapToDto(kit));
    }

    public async Task<JsonModel<List<SchoolKitDto>>> GetKitsByGradeIdAsync(Guid gradeId, CancellationToken ct = default)
    {
        var kits = await _schoolKitRepo.GetByGradeIdAsync(gradeId, ct);
        var dtos = kits.Select(MapToDto).ToList();
        return JsonModel<List<SchoolKitDto>>.Success(dtos);
    }

    public async Task<JsonModel<List<SchoolKitDto>>> GetPagedKitsAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (kits, total) = await _schoolKitRepo.GetPagedAsync(request, ct);
        var dtos = kits.Select(MapToDto).ToList();
        return new JsonModel<List<SchoolKitDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<SchoolKitDto>> UpdateKitAsync(Guid id, CreateSchoolKitRequest request, CancellationToken ct = default)
    {
        // ── 1. Validate Input Fields ──
        var kit = await _schoolKitRepo.GetByIdAsync(id, ct);
        if (kit == null)
        {
            return JsonModel<SchoolKitDto>.Error("School Kit not found.", 404);
        }

        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Trim().Length < 3 || request.Name.Trim().Length > 200)
        {
            return JsonModel<SchoolKitDto>.Error("Kit Name is required and must be between 3 and 200 characters.", 400);
        }

        if (await _schoolKitRepo.ExistsByNameAsync(request.Name.Trim(), id, ct))
        {
            return JsonModel<SchoolKitDto>.Error($"Another School Kit named '{request.Name}' already exists.", 400);
        }

        var grade = await _gradeRepo.GetByIdAsync(request.GradeId, ct);
        if (grade == null)
        {
            return JsonModel<SchoolKitDto>.Error("The selected Grade does not exist.", 404);
        }

        if (!grade.IsActive)
        {
            return JsonModel<SchoolKitDto>.Error("The selected Grade is currently inactive.", 400);
        }

        // Check for grade name mismatches in kit name
        var allGrades = await _db.Grades.Where(g => !g.IsDeleted).ToListAsync(ct);
        var otherGrades = allGrades.Where(g => g.Id != request.GradeId).ToList();

        foreach (var otherGrade in otherGrades)
        {
            if (!string.IsNullOrEmpty(otherGrade.Name))
            {
                var pattern = $@"\b{System.Text.RegularExpressions.Regex.Escape(otherGrade.Name)}\b";
                if (System.Text.RegularExpressions.Regex.IsMatch(request.Name, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return JsonModel<SchoolKitDto>.Error($"Kit Name cannot reference a different Grade ('{otherGrade.Name}').", 400);
                }
            }

            if (!string.IsNullOrEmpty(otherGrade.ShortName))
            {
                var pattern = $@"\b{System.Text.RegularExpressions.Regex.Escape(otherGrade.ShortName)}\b";
                if (System.Text.RegularExpressions.Regex.IsMatch(request.Name, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return JsonModel<SchoolKitDto>.Error($"Kit Name cannot reference a different Grade ('{otherGrade.ShortName}').", 400);
                }
            }
        }

        if (request.IsActive)
        {
            var hasActiveKit = await _db.SchoolKits.AnyAsync(sk => 
                sk.GradeId == request.GradeId && 
                sk.IsActive && 
                sk.Id != id && 
                !sk.IsDeleted, 
                ct);
            if (hasActiveKit)
            {
                return JsonModel<SchoolKitDto>.Error("An active School Kit already exists for this Grade.", 400);
            }
        }

        if (request.Items == null || !request.Items.Any())
        {
            return JsonModel<SchoolKitDto>.Error("A School Kit must contain at least one item.", 400);
        }

        var groupedItems = request.Items
            .GroupBy(i => i.ItemId)
            .Select(g => new CreateSchoolKitItemRequest(g.Key, g.Sum(i => i.Quantity)))
            .ToList();

        var itemIds = groupedItems.Select(i => i.ItemId).ToList();
        var dbItems = await _itemRepo.GetByIdsAsync(itemIds, ct);

        foreach (var reqItem in groupedItems)
        {
            var dbItem = dbItems.FirstOrDefault(i => i.Id == reqItem.ItemId);
            if (dbItem == null)
            {
                return JsonModel<SchoolKitDto>.Error($"Item with ID '{reqItem.ItemId}' not found.", 404);
            }

            if (!dbItem.IsActive)
            {
                return JsonModel<SchoolKitDto>.Error($"Item '{dbItem.Name}' is currently inactive.", 400);
            }

            if (!dbItem.ItemGrades.Any(ig => ig.GradeId == request.GradeId))
            {
                return JsonModel<SchoolKitDto>.Error($"Item '{dbItem.Name}' does not belong to the selected Grade '{grade.Name}'.", 400);
            }

            if (reqItem.Quantity <= 0)
            {
                return JsonModel<SchoolKitDto>.Error($"Quantity for item '{dbItem.Name}' must be greater than zero.", 400);
            }
        }

        // ── 2. Update Kit inside Database Transaction ──
        await _unitOfWork.BeginTransactionAsync(ct);
        try
        {
            kit.Name = request.Name.Trim();
            kit.Description = request.Description?.Trim();
            kit.GradeId = request.GradeId;
            kit.IsActive = request.IsActive;

            // Clear old items directly via DbContext
            var oldItems = _db.SchoolKitItems.Where(ski => ski.SchoolKitId == kit.Id);
            _db.SchoolKitItems.RemoveRange(oldItems);

            // Add new items
            foreach (var reqItem in groupedItems)
            {
                kit.KitItems.Add(new SchoolKitItem
                {
                    SchoolKitId = kit.Id,
                    ItemId = reqItem.ItemId,
                    Quantity = reqItem.Quantity
                });
            }

            _schoolKitRepo.Update(kit);

            await _unitOfWork.CommitTransactionAsync(ct);

            var loadedKit = await _schoolKitRepo.GetByIdAsync(kit.Id, ct);
            return JsonModel<SchoolKitDto>.Success(MapToDto(loadedKit!), "School Kit updated successfully.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(ct);
            return JsonModel<SchoolKitDto>.Error($"Failed to update School Kit: {ex.Message}");
        }
    }

    public async Task<JsonModel<bool>> DeleteKitAsync(Guid id, CancellationToken ct = default)
    {
        var kit = await _schoolKitRepo.GetByIdAsync(id, ct);
        if (kit == null)
        {
            return JsonModel<bool>.Error("School Kit not found.", 404);
        }

        _schoolKitRepo.Delete(kit);
        var success = await _unitOfWork.CommitAsync(ct);

        return JsonModel<bool>.Success(success, "School Kit deleted successfully.");
    }

    private SchoolKitDto MapToDto(SchoolKit kit)
    {
        var itemDtos = kit.KitItems.Select(ki => new SchoolKitItemDto(
            ki.ItemId,
            ki.Item?.Name ?? "Unknown Item",
            ki.Item?.Price ?? 0m,
            ki.Item?.Mrp ?? 0m,
            ki.Quantity,
            ki.Item?.Category?.Name ?? "Unknown Category",
            ki.Item?.Unit ?? "Pieces (Pcs)"
        )).ToList();

        return new SchoolKitDto(
            kit.Id,
            kit.Name,
            kit.Description,
            kit.GradeId,
            kit.Grade?.Name ?? "Unknown Grade",
            kit.IsActive,
            itemDtos,
            kit.CreatedAt
        );
    }
}
