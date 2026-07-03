using Himgiri.Core.Entities;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Repositories;

public interface IGradeRepository
{
    Task<List<Grade>> GetAllAsync(CancellationToken ct = default);
    Task<(List<Grade> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    Task<Grade?> GetByIdAsync(Guid id, CancellationToken ct = default);
    void Add(Grade grade);
    void Update(Grade grade);
    void Delete(Grade grade);
    Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default);
    Task<bool> HasLinkedItemsAsync(Guid id, CancellationToken ct = default);
}

public interface ICategoryRepository
{
    Task<List<ItemCategory>> GetAllAsync(CancellationToken ct = default);
    Task<(List<ItemCategory> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    Task<ItemCategory?> GetByIdAsync(Guid id, CancellationToken ct = default);
    void Add(ItemCategory category);
    void Update(ItemCategory category);
    void Delete(ItemCategory category);
    Task<List<string>> GetSuggestionsAsync(string term, CancellationToken ct = default);
    Task<bool> HasLinkedItemsAsync(Guid id, CancellationToken ct = default);
}

public interface IGstRateRepository
{
    Task<List<GstRate>> GetAllAsync(CancellationToken ct = default);
    Task<(List<GstRate> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    Task<GstRate?> GetByIdAsync(Guid id, CancellationToken ct = default);
    void Add(GstRate rate);
    void Update(GstRate rate);
    void Delete(GstRate rate);
    Task<bool> HasLinkedCategoriesOrItemsAsync(Guid id, CancellationToken ct = default);
}

public interface IStateRepository
{
    Task<List<State>> GetAllActiveAsync(CancellationToken ct = default);
    Task<List<State>> GetAllAsync(CancellationToken ct = default);
    Task<State?> GetByIdAsync(Guid id, CancellationToken ct = default);
}
