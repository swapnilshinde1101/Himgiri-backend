using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class GradesController : BaseController
{
    private readonly IGradeService _service;
    public GradesController(IGradeService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BaseRequest request, CancellationToken ct)
    {
        var result = await _service.GetPagedAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Create([FromBody] GradeDto request, CancellationToken ct)
    {
        var result = await _service.CreateAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] GradeDto request, CancellationToken ct)
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
