using Himgiri.Core.Constants;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Services;

public class StockService : IStockService
{
    private readonly HimgiriDbContext _db;
    
    // Low stock threshold isolated as a constant configuration variable
    private const int LowStockThreshold = 10;

    public StockService(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task<JsonModel<bool>> UpdateStockAsync(Guid itemId, UpdateStockRequest request, string changedBy, CancellationToken ct = default)
    {
        // 1. Validate Reason against allowed system constants
        if (!StockReasons.AllReasons.Contains(request.Reason))
        {
            return JsonModel<bool>.Error($"Invalid stock adjustment reason. Allowed values: {string.Join(", ", StockReasons.AllReasons)}");
        }

        using var transaction = await _db.Database.BeginTransactionAsync(ct);
        try
        {
            // 2. Find target item
            var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == itemId && !i.IsDeleted, ct);
            if (item == null)
            {
                return JsonModel<bool>.Error("Item not found", 404);
            }

            if (!item.IsActive)
            {
                return JsonModel<bool>.Error($"Cannot adjust stock for inactive item '{item.Name}'.", 400);
            }

            // Concurrency Check
            if (request.LastSeenStockQty.HasValue && item.StockQty != request.LastSeenStockQty.Value)
            {
                return JsonModel<bool>.Error($"Stock has been modified by another user. Current stock is {item.StockQty}, but you saw {request.LastSeenStockQty.Value}. Please refresh and try again.", 409);
            }

            int oldQty = item.StockQty;
            int newQty = oldQty + request.AdjustmentQty;

            // 3. Validate quantity is non-negative
            if (newQty < 0)
            {
                return JsonModel<bool>.Error($"Stock quantity cannot be negative (current: {oldQty}, adjustment: {request.AdjustmentQty}).", 400);
            }

            // Validate quantity does not exceed TargetQty
            if (newQty > item.TargetQty)
            {
                return JsonModel<bool>.Error($"Stock quantity cannot exceed Target Quantity of {item.TargetQty} (current: {oldQty}, proposed: {newQty}).", 400);
            }

            item.StockQty = newQty;
            item.IsStockInitialized = true;
            item.UpdatedAt = DateTime.UtcNow;

            // 4. Record stock log audit trail in the same transaction
            var log = new StockLog
            {
                Id = Guid.NewGuid(),
                ItemId = itemId,
                OldQty = oldQty,
                NewQty = newQty,
                ChangedBy = changedBy,
                Reason = request.Reason,
                CreatedAt = DateTime.UtcNow
            };

            _db.StockLogs.Add(log);

            await _db.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return JsonModel<bool>.Success(true, "Stock updated successfully");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            return JsonModel<bool>.Error($"Stock update failed: {ex.Message}");
        }
    }

    public async Task<JsonModel<List<StockLogDto>>> GetStockLogsAsync(Guid itemId, CancellationToken ct = default)
    {
        var logs = await _db.StockLogs
            .Include(l => l.Item)
            .Where(l => l.ItemId == itemId && !l.IsDeleted)
            .OrderByDescending(l => l.CreatedAt)
            .ToListAsync(ct);

        var dtos = logs.Select(l => new StockLogDto(
            l.Id,
            l.ItemId,
            l.Item?.Name ?? "Unknown Item",
            l.OldQty,
            l.NewQty,
            l.ChangedBy,
            l.Reason,
            l.CreatedAt
        )).ToList();

        return JsonModel<List<StockLogDto>>.Success(dtos);
    }

    public async Task<JsonModel<List<StockLogDto>>> GetAllStockLogsAsync(bool onlyCompleted = false, CancellationToken ct = default)
    {
        var query = _db.StockLogs
            .Include(l => l.Item)
            .Where(l => !l.IsDeleted);

        if (onlyCompleted)
        {
            query = query.Where(l => l.Item != null && l.Item.StockQty == l.Item.TargetQty);
        }

        var logs = await query
            .OrderByDescending(l => l.CreatedAt)
            .ToListAsync(ct);

        var dtos = logs.Select(l => new StockLogDto(
            l.Id,
            l.ItemId,
            l.Item?.Name ?? "Unknown Item",
            l.OldQty,
            l.NewQty,
            l.ChangedBy,
            l.Reason,
            l.CreatedAt
        )).ToList();

        return JsonModel<List<StockLogDto>>.Success(dtos);
    }

    public async Task<JsonModel<List<ItemDto>>> GetLowStockItemsAsync(CancellationToken ct = default)
    {
        var items = await _db.Items
            .Include(i => i.Category)
            .Include(i => i.ItemGrades)
                .ThenInclude(ig => ig.Grade)
            .Where(i => i.StockQty < LowStockThreshold && !i.IsDeleted && i.IsStockInitialized)
            .ToListAsync(ct);

        var dtos = items.Select(item => new ItemDto(
            item.Id,
            item.Name,
            item.Description,
            item.ImageUrl,
            item.Price,
            item.PurchasePrice,
            item.Mrp,
            item.StorageStatus,
            item.StockQty,
            item.TargetQty,
            item.Unit,
            item.IsStockInitialized,
            item.Category?.Name ?? string.Empty,
            item.CategoryId,
            item.ItemGrades.Select(ig => ig.GradeId).ToList(),
            string.Join(", ", item.ItemGrades.Select(ig => ig.Grade?.Name).Where(n => !string.IsNullOrEmpty(n))),
            item.IsActive,
            item.CreatedAt,
            item.CompletedAt
        )).ToList();
        
        return JsonModel<List<ItemDto>>.Success(dtos);
    }

    public async Task<JsonModel<List<ItemDto>>> GetOutOfStockItemsAsync(CancellationToken ct = default)
    {
        var items = await _db.Items
            .Include(i => i.Category)
            .Include(i => i.ItemGrades)
                .ThenInclude(ig => ig.Grade)
            .Where(i => i.StockQty == 0 && !i.IsDeleted && i.IsStockInitialized)
            .ToListAsync(ct);

        var dtos = items.Select(item => new ItemDto(
            item.Id,
            item.Name,
            item.Description,
            item.ImageUrl,
            item.Price,
            item.PurchasePrice,
            item.Mrp,
            item.StorageStatus,
            item.StockQty,
            item.TargetQty,
            item.Unit,
            item.IsStockInitialized,
            item.Category?.Name ?? string.Empty,
            item.CategoryId,
            item.ItemGrades.Select(ig => ig.GradeId).ToList(),
            string.Join(", ", item.ItemGrades.Select(ig => ig.Grade?.Name).Where(n => !string.IsNullOrEmpty(n))),
            item.IsActive,
            item.CreatedAt,
            item.CompletedAt
        )).ToList();
        
        return JsonModel<List<ItemDto>>.Success(dtos);
    }


    public async Task<JsonModel<bool>> BulkInwardStockAsync(BulkInwardRequest request, string changedBy, CancellationToken ct = default)
    {
        if (!StockReasons.AllReasons.Contains(request.Reason))
        {
            return JsonModel<bool>.Error($"Invalid stock adjustment reason. Allowed values: {string.Join(", ", StockReasons.AllReasons)}");
        }

        if (request.Items == null || !request.Items.Any())
        {
            return JsonModel<bool>.Error("No items provided for inwarding.");
        }

        using var transaction = await _db.Database.BeginTransactionAsync(ct);
        try
        {
            foreach (var itemDto in request.Items)
            {
                if (itemDto.QuantityToAdd < 0)
                {
                    return JsonModel<bool>.Error($"Inward quantity cannot be negative for item {itemDto.ItemId}.");
                }

                var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == itemDto.ItemId && !i.IsDeleted, ct);
                if (item == null)
                {
                    return JsonModel<bool>.Error($"Item with ID {itemDto.ItemId} not found.", 404);
                }

                if (!item.IsActive)
                {
                    return JsonModel<bool>.Error($"Cannot inward stock for inactive item '{item.Name}'.", 400);
                }

                int oldQty = item.StockQty;
                int newQty = oldQty + itemDto.QuantityToAdd;

                // Validate quantity does not exceed TargetQty
                if (newQty > item.TargetQty)
                {
                    return JsonModel<bool>.Error($"Inward quantity for item '{item.Name}' would exceed its Target Quantity of {item.TargetQty} (current: {oldQty}, proposed: {newQty}).", 400);
                }

                item.StockQty = newQty;
                item.IsStockInitialized = true;
                item.UpdatedAt = DateTime.UtcNow;

                var log = new StockLog
                {
                    Id = Guid.NewGuid(),
                    ItemId = item.Id,
                    OldQty = oldQty,
                    NewQty = newQty,
                    ChangedBy = changedBy,
                    Reason = request.Reason,
                    CreatedAt = DateTime.UtcNow
                };

                _db.StockLogs.Add(log);
            }

            await _db.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return JsonModel<bool>.Success(true, "Bulk stock inwarded successfully");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            return JsonModel<bool>.Error($"Bulk inwarding failed: {ex.Message}");
        }
    }

    public async Task<bool> AdjustStockInternalAsync(Guid itemId, int qtyChange, string reason, string changedBy, CancellationToken ct = default)
    {
        // 1. Validate Reason against allowed constants
        if (!StockReasons.AllReasons.Contains(reason))
        {
            throw new ArgumentException($"Invalid stock adjustment reason: {reason}");
        }

        // 2. Fetch the item
        var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == itemId && !i.IsDeleted, ct);
        if (item == null)
        {
            throw new KeyNotFoundException($"Item with ID {itemId} not found.");
        }

        if (!item.IsActive)
        {
            throw new InvalidOperationException($"Cannot adjust stock for inactive item '{item.Name}'.");
        }

        int oldQty = item.StockQty;
        int newQty = oldQty + qtyChange;

        // Validation rule: No Negative Stock
        if (newQty < 0)
        {
            throw new InvalidOperationException($"Stock adjustment would result in negative stock ({newQty}) for item '{item.Name}'.");
        }

        // Validation rule: No Exceeding Target Stock
        if (newQty > item.TargetQty)
        {
            throw new InvalidOperationException($"Stock adjustment would exceed Target Quantity ({item.TargetQty}) for item '{item.Name}'.");
        }

        item.StockQty = newQty;
        item.IsStockInitialized = true;
        item.UpdatedAt = DateTime.UtcNow;

        // 3. Log transaction audit trail in the same transaction context
        var log = new StockLog
        {
            Id = Guid.NewGuid(),
            ItemId = itemId,
            OldQty = oldQty,
            NewQty = newQty,
            ChangedBy = changedBy,
            Reason = reason,
            CreatedAt = DateTime.UtcNow
        };

        _db.StockLogs.Add(log);

        await _db.SaveChangesAsync(ct);
        return true;
    }
}
