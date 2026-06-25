using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Authorize]
public class ItemsController : BaseController
{
    private readonly IItemService _itemService;
    private readonly IStockService _stockService;

    public ItemsController(IItemService itemService, IStockService stockService)
    {
        _itemService = itemService;
        _stockService = stockService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetItem(Guid id, CancellationToken ct)
    {
        var result = await _itemService.GetItemAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetItems([FromQuery] BaseRequest request, CancellationToken ct)
    {
        var result = await _itemService.GetItemsAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemRequest request, CancellationToken ct)
    {
        var result = await _itemService.CreateItemAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] CreateItemRequest request, CancellationToken ct)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                    User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                    User.Identity?.Name ?? "System";

        var result = await _itemService.UpdateItemAsync(id, request, email, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> DeleteItem(Guid id, CancellationToken ct)
    {
        var result = await _itemService.DeleteItemAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("suggestions")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSuggestions([FromQuery] string term, CancellationToken ct)
    {
        var result = await _itemService.GetSuggestionsAsync(term, ct);
        return OkResponse(result.Data, result.Message);
    }

    [HttpPatch("{id:guid}/stock")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> UpdateStock(Guid id, [FromBody] UpdateStockRequest request, CancellationToken ct)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                    User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                    User.Identity?.Name ?? "System";

        var result = await _stockService.UpdateStockAsync(id, request, email, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:guid}/stock-logs")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetStockLogs(Guid id, CancellationToken ct)
    {
        var result = await _stockService.GetStockLogsAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:guid}/price-logs")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetPriceLogs(Guid id, CancellationToken ct)
    {
        var result = await _itemService.GetPriceAuditLogsAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("stock/logs")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetAllStockLogs([FromQuery] bool onlyCompleted = false, CancellationToken ct = default)
    {
        var result = await _stockService.GetAllStockLogsAsync(onlyCompleted, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("stock/bulk-inward")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> BulkInwardStock([FromBody] BulkInwardRequest request, CancellationToken ct)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                    User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                    User.Identity?.Name ?? "System";

        var result = await _stockService.BulkInwardStockAsync(request, email, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("bulk-status")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> BulkToggleActive([FromBody] BulkStatusRequest request, CancellationToken ct)
    {
        var result = await _itemService.BulkToggleActiveAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("bulk-category")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> BulkUpdateCategory([FromBody] BulkCategoryRequest request, CancellationToken ct)
    {
        var result = await _itemService.BulkUpdateCategoryAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("stock/low")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetLowStock(CancellationToken ct)
    {
        var result = await _stockService.GetLowStockItemsAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("stock/out")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetOutOfStock(CancellationToken ct)
    {
        var result = await _stockService.GetOutOfStockItemsAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("completed/stats")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetCompletedStats(CancellationToken ct)
    {
        var result = await _itemService.GetCompletedStatsAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("dashboard/stats")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> GetDashboardStats(CancellationToken ct)
    {
        var result = await _itemService.GetDashboardStatsAsync(ct);
        return StatusCode(result.StatusCode, result);
    }
}
