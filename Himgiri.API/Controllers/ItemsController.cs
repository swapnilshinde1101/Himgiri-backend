using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Himgiri.API.Controllers;

[Authorize]
public class ItemsController : BaseController
{
    private readonly IItemService _itemService;
    private readonly IStockService _stockService;
    private readonly IConfiguration _config;

    public ItemsController(IItemService itemService, IStockService stockService, IConfiguration config)
    {
        _itemService = itemService;
        _stockService = stockService;
        _config = config;
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

    [HttpPost("upload-image")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> UploadImage(IFormFile file, CancellationToken ct)
    {
        if (file == null || file.Length == 0)
        {
            return ErrorResponse("No file was uploaded.");
        }

        // Validate size (5MB limit)
        if (file.Length > 5 * 1024 * 1024)
        {
            return ErrorResponse("File size exceeds the 5MB limit.");
        }

        // Validate type (Images only)
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
        {
            return ErrorResponse("Invalid image format. Allowed formats: JPG, JPEG, PNG, WEBP.");
        }

        try
        {
            var supabaseUrl = _config["Supabase:Url"];
            var supabaseKey = _config["Supabase:AnonKey"];
            var bucketName = _config["Supabase:BucketName"];

            if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey) || string.IsNullOrEmpty(bucketName))
            {
                return ErrorResponse("Supabase storage is not configured on the server.");
            }

            // Generate unique file name
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var uploadUrl = $"{supabaseUrl.TrimEnd('/')}/storage/v1/object/{bucketName}/{uniqueFileName}";

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {supabaseKey}");
            httpClient.DefaultRequestHeaders.Add("apikey", supabaseKey);

            using var stream = file.OpenReadStream();
            using var content = new StreamContent(stream);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

            var response = await httpClient.PostAsync(uploadUrl, content, ct);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync(ct);
                return ErrorResponse($"Failed to upload to cloud storage: {response.ReasonPhrase}. Details: {errorContent}");
            }

            var publicUrl = $"{supabaseUrl.TrimEnd('/')}/storage/v1/object/public/{bucketName}/{uniqueFileName}";
            return OkResponse(new { imageUrl = publicUrl }, "Image uploaded successfully");
        }
        catch (Exception ex)
        {
            return ErrorResponse($"An error occurred while uploading: {ex.Message}");
        }
    }
}
