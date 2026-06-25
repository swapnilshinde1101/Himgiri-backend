using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[AllowAnonymous]
public class CatalogController : BaseController
{
    private readonly IItemService _itemService;

    public CatalogController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCatalog([FromQuery] BaseRequest request, CancellationToken ct)
    {
        var result = await _itemService.GetCatalogItemsByGradeAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }
}
