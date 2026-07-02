using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IStockService
{
    Task<JsonModel<bool>> UpdateStockAsync(Guid itemId, UpdateStockRequest request, string changedBy, CancellationToken ct = default);
    Task<JsonModel<List<StockLogDto>>> GetStockLogsAsync(Guid itemId, CancellationToken ct = default);
    Task<JsonModel<List<StockLogDto>>> GetAllStockLogsAsync(bool onlyCompleted = false, CancellationToken ct = default);
    Task<JsonModel<List<ItemDto>>> GetLowStockItemsAsync(CancellationToken ct = default);
    Task<JsonModel<List<ItemDto>>> GetOutOfStockItemsAsync(CancellationToken ct = default);
    Task<JsonModel<bool>> BulkInwardStockAsync(BulkInwardRequest request, string changedBy, CancellationToken ct = default);
    
    // Internal integration method for OrderService / PurchaseService
    Task<bool> AdjustStockInternalAsync(Guid itemId, int qtyChange, string reason, string changedBy, CancellationToken ct = default);
}
