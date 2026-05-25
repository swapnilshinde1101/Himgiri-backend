using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IItemService
{
    Task<JsonModel<ItemDto>> GetItemAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<List<ItemDto>>> GetItemsAsync(BaseRequest request, CancellationToken ct = default);
    Task<JsonModel<ItemDto>> CreateItemAsync(CreateItemRequest request, CancellationToken ct = default);
    Task<JsonModel<ItemDto>> UpdateItemAsync(Guid id, CreateItemRequest request, CancellationToken ct = default);
    Task<JsonModel<bool>> DeleteItemAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<List<string>>> GetSuggestionsAsync(string term, CancellationToken ct = default);
}
