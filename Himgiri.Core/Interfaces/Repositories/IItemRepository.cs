using Himgiri.Core.Entities;
using Himgiri.Core.Models;
using Himgiri.Core.DTOs;

namespace Himgiri.Core.Interfaces.Repositories;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<Item>> GetByIdsAsync(List<Guid> ids, CancellationToken ct = default);
    Task<(List<Item> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    void Add(Item item);
    void Update(Item item);
    void Delete(Item item);
    void AddStockLog(StockLog log);
    void AddPriceAuditLog(PriceAuditLog log);
    Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken ct = default);
    Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default);
    Task<CompletedStatsDto> GetCompletedStatsAsync(CancellationToken ct = default);
    Task<DashboardStatsDto> GetDashboardStatsAsync(CancellationToken ct = default);
    Task<List<Item>> GetCatalogItemsByGradeAsync(Guid gradeId, CancellationToken ct = default);
    Task<List<PriceAuditLog>> GetPriceAuditLogsAsync(Guid itemId, CancellationToken ct = default);
}
