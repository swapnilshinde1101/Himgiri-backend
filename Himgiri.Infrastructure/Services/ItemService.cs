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
    private readonly IUnitOfWork _unitOfWork;

    public ItemService(IItemRepository itemRepo, IUnitOfWork unitOfWork)
    {
        _itemRepo = itemRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<JsonModel<ItemDto>> GetItemAsync(Guid id, CancellationToken ct = default)
    {
        var item = await _itemRepo.GetByIdAsync(id, ct);
        if (item == null) return JsonModel<ItemDto>.Error("Item not found", 404);

        return JsonModel<ItemDto>.Success(item.Adapt<ItemDto>());
    }

    public async Task<JsonModel<List<ItemDto>>> GetItemsAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (items, total) = await _itemRepo.GetPagedAsync(request, ct);
        var dtos = items.Adapt<List<ItemDto>>();
        
        return new JsonModel<List<ItemDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<ItemDto>> CreateItemAsync(CreateItemRequest request, CancellationToken ct = default)
    {
        if (await _itemRepo.ExistsByNameAsync(request.Name, null, ct))
            return JsonModel<ItemDto>.Error("An item with this name already exists.");

        var item = request.Adapt<Item>();
        _itemRepo.Add(item);
        
        await _unitOfWork.CommitAsync(ct);
        
        return await GetItemAsync(item.Id, ct);
    }

    public async Task<JsonModel<ItemDto>> UpdateItemAsync(Guid id, CreateItemRequest request, CancellationToken ct = default)
    {
        var item = await _itemRepo.GetByIdAsync(id, ct);
        if (item == null) return JsonModel<ItemDto>.Error("Item not found", 404);

        if (await _itemRepo.ExistsByNameAsync(request.Name, id, ct))
            return JsonModel<ItemDto>.Error("An item with this name already exists.");

        request.Adapt(item);
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
}
