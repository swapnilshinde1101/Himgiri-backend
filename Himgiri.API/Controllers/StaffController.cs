using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.API.Attributes;
using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Route("api/staff")]
[Authorize(Policy = "SuperAdmin")]
[RequirePermission(Permissions.StaffManage)]
public class StaffController : BaseController
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStaff(CancellationToken ct)
    {
        var result = await _staffService.GetAllStaffAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStaffById(Guid id, CancellationToken ct)
    {
        var result = await _staffService.GetStaffByIdAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStaff([FromBody] CreateStaffRequest request, CancellationToken ct)
    {
        var result = await _staffService.CreateStaffAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/role")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] UpdateStaffRoleRequest request, CancellationToken ct)
    {
        var currentUserId = GetCurrentUserId();
        var result = await _staffService.UpdateStaffRoleAsync(id, request, currentUserId, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStaffStatusRequest request, CancellationToken ct)
    {
        var currentUserId = GetCurrentUserId();
        var result = await _staffService.UpdateStaffStatusAsync(id, request, currentUserId, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("{id:guid}/reset-password")]
    public async Task<IActionResult> ResetPassword(Guid id, [FromBody] ResetStaffPasswordRequest request, CancellationToken ct)
    {
        var result = await _staffService.ResetStaffPasswordAsync(id, request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("{id:guid}/unlock")]
    public async Task<IActionResult> UnlockAccount(Guid id, CancellationToken ct)
    {
        var result = await _staffService.UnlockStaffAccountAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStaff(Guid id, CancellationToken ct)
    {
        var currentUserId = GetCurrentUserId();
        var result = await _staffService.DeleteStaffAsync(id, currentUserId, ct);
        return StatusCode(result.StatusCode, result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : Guid.Empty;
    }
}
