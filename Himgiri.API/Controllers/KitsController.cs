using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class KitsController : BaseController
{
    private readonly ISchoolKitService _kitService;

    public KitsController(ISchoolKitService kitService)
    {
        _kitService = kitService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] BaseRequest request, CancellationToken ct)
    {
        var result = await _kitService.GetPagedKitsAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await _kitService.GetKitByIdAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("grade/{gradeId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByGrade(Guid gradeId, CancellationToken ct)
    {
        var result = await _kitService.GetKitsByGradeIdAsync(gradeId, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> Create([FromBody] CreateSchoolKitRequest request, CancellationToken ct)
    {
        var result = await _kitService.CreateKitAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "InventoryOrAdmin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateSchoolKitRequest request, CancellationToken ct)
    {
        var result = await _kitService.UpdateKitAsync(id, request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _kitService.DeleteKitAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }
}
