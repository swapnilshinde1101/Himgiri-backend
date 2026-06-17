using Himgiri.Core.Interfaces.Services;
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
    public async Task<IActionResult> GetCatalog([FromQuery] Guid? gradeId, CancellationToken ct)
    {
        var result = await _itemService.GetCatalogItemsByGradeAsync(gradeId, ct);
        return StatusCode(result.StatusCode, result);
    }
}
