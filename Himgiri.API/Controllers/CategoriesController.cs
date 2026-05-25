using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class CategoriesController : BaseController
{
    private readonly ICategoryService _service;
    public CategoriesController(ICategoryService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BaseRequest request, CancellationToken ct)
    {
        var result = await _service.GetPagedAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Create([FromBody] CategoryDto request, CancellationToken ct)
    {
        var result = await _service.CreateAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryDto request, CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _service.DeleteAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("suggestions")]
    public async Task<IActionResult> GetSuggestions([FromQuery] string term, CancellationToken ct)
    {
        var result = await _service.GetSuggestionsAsync(term, ct);
        return OkResponse(result.Data, result.Message);
    }
}
