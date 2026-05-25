using Himgiri.Core.Entities;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Repositories;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<(List<Item> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    void Add(Item item);
    void Update(Item item);
    void Delete(Item item);
    void AddStockLog(StockLog log);
    Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken ct = default);
    Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default);
}
