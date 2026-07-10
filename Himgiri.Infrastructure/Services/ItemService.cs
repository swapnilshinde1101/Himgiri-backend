using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Mapster;

namespace Himgiri.Infrastructure.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepo;
    private readonly ICategoryRepository _categoryRepo;
    private readonly IGstRateRepository _gstRateRepo;
    private readonly IUnitOfWork _unitOfWork;

    public ItemService(IItemRepository itemRepo, ICategoryRepository categoryRepo, IGstRateRepository gstRateRepo, IUnitOfWork unitOfWork)
    {
        _itemRepo = itemRepo;
        _categoryRepo = categoryRepo;
        _gstRateRepo = gstRateRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<JsonModel<ItemDto>> GetItemAsync(Guid id, CancellationToken ct = default)
    {
        var item = await _itemRepo.GetByIdAsync(id, ct);
        if (item == null) return JsonModel<ItemDto>.Error("Item not found", 404);

        var dto = new ItemDto(
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
            item.CompletedAt,
            item.GstRateId,
            item.LowStockThreshold
        );

        return JsonModel<ItemDto>.Success(dto);
    }

    public async Task<JsonModel<List<ItemDto>>> GetItemsAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (items, total) = await _itemRepo.GetPagedAsync(request, ct);
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
            item.CompletedAt,
            item.GstRateId,
            item.LowStockThreshold
        )).ToList();
        
        return new JsonModel<List<ItemDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<ItemDto>> CreateItemAsync(CreateItemRequest request, CancellationToken ct = default)
    {
        if (request.Price <= 0)
            return JsonModel<ItemDto>.Error("Selling Price must be greater than 0.", 400);

        if (request.Mrp <= 0)
            return JsonModel<ItemDto>.Error("MRP must be greater than 0.", 400);

        if (request.PurchasePrice.HasValue && request.PurchasePrice.Value < 0)
            return JsonModel<ItemDto>.Error("Purchase Price cannot be negative.", 400);

        if (await _itemRepo.ExistsByNameAsync(request.Name, null, ct))
            return JsonModel<ItemDto>.Error("An item with this name already exists.");

        var category = await _categoryRepo.GetByIdAsync(request.CategoryId, ct);
        if (category == null)
            return JsonModel<ItemDto>.Error("Category not found.");

        decimal gstPercent = 0m;
        if (request.GstRateId.HasValue)
        {
            var gstRate = await _gstRateRepo.GetByIdAsync(request.GstRateId.Value, ct);
            if (gstRate == null)
                return JsonModel<ItemDto>.Error("GST Rate not found.");
            if (!gstRate.IsActive)
                return JsonModel<ItemDto>.Error("Selected GST Rate is currently inactive.");
            gstPercent = gstRate.Rate;
        }
        else
        {
            if (category.DefaultGstRate == null)
            {
                return JsonModel<ItemDto>.Error("GST Rate is not configured on the Category. Please set a Default GST Rate on the Category first.", 400);
            }
            gstPercent = category.DefaultGstRate.Rate;
        }

        var sellingPriceWithGst = request.Price * (1 + gstPercent / 100m);
        if (sellingPriceWithGst > request.Mrp)
        {
            return JsonModel<ItemDto>.Error($"Selling Price inclusive of GST (₹{sellingPriceWithGst:F2}) cannot exceed MRP (₹{request.Mrp:F2}).");
        }

        var item = new Item
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Price = request.Price,
            PurchasePrice = request.PurchasePrice,
            Mrp = request.Mrp,
            StorageStatus = request.StorageStatus,
            StockQty = request.StockQty,
            TargetQty = request.TargetQty,
            Unit = request.Unit ?? "Pieces (Pcs)",
            CategoryId = request.CategoryId,
            GstRateId = request.GstRateId,
            IsActive = request.IsActive,
            IsStockInitialized = request.IsStockInitialized || request.StockQty > 0,
            LowStockThreshold = request.LowStockThreshold
        };

        if (request.GradeIds != null)
        {
            foreach (var gradeId in request.GradeIds)
            {
                item.ItemGrades.Add(new ItemGrade { ItemId = item.Id, GradeId = gradeId });
            }
        }

        _itemRepo.Add(item);
        
        // Write initial stock audit log in the same transaction
        if (item.StockQty > 0)
        {
            var log = new StockLog
            {
                Id = Guid.NewGuid(),
                ItemId = item.Id,
                OldQty = 0,
                NewQty = item.StockQty,
                ChangedBy = "System / Initial Stock",
                Reason = "Manual Update",
                CreatedAt = DateTime.UtcNow
            };
            _itemRepo.AddStockLog(log);
        }

        await _unitOfWork.CommitAsync(ct);
        
        return await GetItemAsync(item.Id, ct);
    }

    public async Task<JsonModel<ItemDto>> UpdateItemAsync(Guid id, CreateItemRequest request, string changedBy = "System", CancellationToken ct = default)
    {
        var item = await _itemRepo.GetByIdAsync(id, ct);
        if (item == null) return JsonModel<ItemDto>.Error("Item not found", 404);

        if (request.Price <= 0)
            return JsonModel<ItemDto>.Error("Selling Price must be greater than 0.", 400);

        if (request.Mrp <= 0)
            return JsonModel<ItemDto>.Error("MRP must be greater than 0.", 400);

        if (request.PurchasePrice.HasValue && request.PurchasePrice.Value < 0)
            return JsonModel<ItemDto>.Error("Purchase Price cannot be negative.", 400);

        if (await _itemRepo.ExistsByNameAsync(request.Name, id, ct))
            return JsonModel<ItemDto>.Error("An item with this name already exists.");

        var category = await _categoryRepo.GetByIdAsync(request.CategoryId, ct);
        if (category == null)
            return JsonModel<ItemDto>.Error("Category not found.");

        decimal gstPercent = 0m;
        if (request.GstRateId.HasValue)
        {
            var gstRate = await _gstRateRepo.GetByIdAsync(request.GstRateId.Value, ct);
            if (gstRate == null)
                return JsonModel<ItemDto>.Error("GST Rate not found.");
            if (!gstRate.IsActive)
                return JsonModel<ItemDto>.Error("Selected GST Rate is currently inactive.");
            gstPercent = gstRate.Rate;
        }
        else
        {
            if (category.DefaultGstRate == null)
            {
                return JsonModel<ItemDto>.Error("GST Rate is not configured on the Category. Please set a Default GST Rate on the Category first.", 400);
            }
            gstPercent = category.DefaultGstRate.Rate;
        }

        var sellingPriceWithGst = request.Price * (1 + gstPercent / 100m);
        if (sellingPriceWithGst > request.Mrp)
        {
            return JsonModel<ItemDto>.Error($"Selling Price inclusive of GST (₹{sellingPriceWithGst:F2}) cannot exceed MRP (₹{request.Mrp:F2}).");
        }

        var wasInitialized = item.IsStockInitialized;
        
        int oldQty = item.StockQty;
        int newQty = request.StockQty;

        decimal oldPrice = item.Price;
        decimal newPrice = request.Price;
        decimal oldMrp = item.Mrp;
        decimal newMrp = request.Mrp;

        item.Name = request.Name;
        item.Description = request.Description;
        item.ImageUrl = request.ImageUrl;
        item.Price = request.Price;
        item.PurchasePrice = request.PurchasePrice;
        item.Mrp = request.Mrp;
        item.StorageStatus = request.StorageStatus;
        item.StockQty = request.StockQty;
        item.TargetQty = request.TargetQty;
        item.Unit = request.Unit ?? "Pieces (Pcs)";
        item.CategoryId = request.CategoryId;
        item.GstRateId = request.GstRateId;
        item.IsActive = request.IsActive;
        item.IsStockInitialized = request.IsStockInitialized || request.StockQty > 0;
        item.LowStockThreshold = request.LowStockThreshold;

        // Log manual stock update if changed on Edit form
        if (oldQty != newQty)
        {
            var log = new StockLog
            {
                Id = Guid.NewGuid(),
                ItemId = item.Id,
                OldQty = oldQty,
                NewQty = newQty,
                ChangedBy = "System / Item Edit Form",
                Reason = newQty > oldQty ? "Manual Inward" : "Manual Correction",
                CreatedAt = DateTime.UtcNow
            };
            _itemRepo.AddStockLog(log);
        }

        // Log manual price update if changed
        if (oldPrice != newPrice || oldMrp != newMrp)
        {
            var priceLog = new PriceAuditLog
            {
                Id = Guid.NewGuid(),
                ItemId = item.Id,
                OldPrice = oldPrice,
                NewPrice = newPrice,
                OldMrp = oldMrp,
                NewMrp = newMrp,
                ChangedBy = changedBy,
                Reason = "Price updated via edit form",
                CreatedAt = DateTime.UtcNow
            };
            _itemRepo.AddPriceAuditLog(priceLog);
        }
        
        // Sync item grades
        var existingGradeIds = item.ItemGrades.Select(ig => ig.GradeId).ToList();
        var newGradeIds = request.GradeIds ?? new List<Guid>();

        // Remove removed associations
        var toRemove = item.ItemGrades.Where(ig => !newGradeIds.Contains(ig.GradeId)).ToList();
        foreach (var ig in toRemove)
        {
            item.ItemGrades.Remove(ig);
        }

        // Add new associations
        var toAdd = newGradeIds.Where(gid => !existingGradeIds.Contains(gid))
                               .Select(gid => new ItemGrade { ItemId = item.Id, GradeId = gid });
        foreach (var ig in toAdd)
        {
            item.ItemGrades.Add(ig);
        }

        _itemRepo.Update(item);
        
        await _unitOfWork.CommitAsync(ct);
        
        return await GetItemAsync(id, ct);
    }

    public async Task<JsonModel<bool>> DeleteItemAsync(Guid id, CancellationToken ct = default)
    {
        var item = await _itemRepo.GetByIdAsync(id, ct);
        if (item == null) return JsonModel<bool>.Error("Item not found", 404);

        _itemRepo.Delete(item);
        var success = await _unitOfWork.CommitAsync(ct);
        
        return JsonModel<bool>.Success(success, "Item deleted successfully");
    }

    public async Task<JsonModel<List<string>>> GetSuggestionsAsync(string term, CancellationToken ct = default)
    {
        var suggestions = await _itemRepo.GetSuggestionsAsync(term, ct);
        return JsonModel<List<string>>.Success(suggestions);
    }

    public async Task<JsonModel<bool>> BulkToggleActiveAsync(BulkStatusRequest request, CancellationToken ct = default)
    {
        if (request.ItemIds == null || !request.ItemIds.Any())
            return JsonModel<bool>.Error("No items specified.");

        var items = await _itemRepo.GetByIdsAsync(request.ItemIds, ct);
        if (!items.Any())
            return JsonModel<bool>.Error("No valid items found.");

        foreach (var item in items)
        {
            item.IsActive = request.IsActive;
            _itemRepo.Update(item);
        }

        var success = await _unitOfWork.CommitAsync(ct);
        return JsonModel<bool>.Success(success, $"Successfully updated active status for {items.Count} items.");
    }

    public async Task<JsonModel<bool>> BulkUpdateCategoryAsync(BulkCategoryRequest request, CancellationToken ct = default)
    {
        if (request.ItemIds == null || !request.ItemIds.Any())
            return JsonModel<bool>.Error("No items specified.");

        var items = await _itemRepo.GetByIdsAsync(request.ItemIds, ct);
        if (!items.Any())
            return JsonModel<bool>.Error("No valid items found.");

        foreach (var item in items)
        {
            item.CategoryId = request.CategoryId;
            _itemRepo.Update(item);
        }

        var success = await _unitOfWork.CommitAsync(ct);
        return JsonModel<bool>.Success(success, $"Successfully updated category for {items.Count} items.");
    }

    public async Task<JsonModel<CompletedStatsDto>> GetCompletedStatsAsync(CancellationToken ct = default)
    {
        var stats = await _itemRepo.GetCompletedStatsAsync(ct);
        return JsonModel<CompletedStatsDto>.Success(stats);
    }

    public async Task<JsonModel<DashboardStatsDto>> GetDashboardStatsAsync(CancellationToken ct = default)
    {
        var stats = await _itemRepo.GetDashboardStatsAsync(ct);
        return JsonModel<DashboardStatsDto>.Success(stats);
    }

    public async Task<JsonModel<List<CatalogItemDto>>> GetCatalogItemsByGradeAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (items, total) = await _itemRepo.GetCatalogItemsByGradeAsync(request, ct);
        var dtos = items.Select(item => new CatalogItemDto(
            item.Id,
            item.Name,
            item.Description,
            item.ImageUrl,
            item.Price,
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
            item.CompletedAt,
            item.LowStockThreshold
        )).ToList();

        return new JsonModel<List<CatalogItemDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<List<PriceAuditLogDto>>> GetPriceAuditLogsAsync(Guid itemId, CancellationToken ct = default)
    {
        var logs = await _itemRepo.GetPriceAuditLogsAsync(itemId, ct);
        var dtos = logs.Select(l => new PriceAuditLogDto(
            l.Id,
            l.ItemId,
            l.Item?.Name ?? "Unknown Item",
            l.OldPrice,
            l.NewPrice,
            l.OldMrp,
            l.NewMrp,
            l.ChangedBy,
            l.Reason,
            l.CreatedAt
        )).ToList();

        return JsonModel<List<PriceAuditLogDto>>.Success(dtos);
    }
}
