using System;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.API.Attributes;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[ApiController]
[Route("api/reports")]
[Authorize(Policy = "AnyAdmin")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    /// <summary>
    /// Gets aggregated accounting figures: total paid sales, pending receivables, tax distributions, refunds, and grade sales.
    /// </summary>
    [HttpGet("accounts/summary")]
    [RequirePermission(Permissions.ReportsAccounts)]
    public async Task<IActionResult> GetAccountSummary(
        [FromQuery] DateTime? startDate, 
        [FromQuery] DateTime? endDate, 
        CancellationToken ct)
    {
        var result = await _reportService.GetAccountReportSummaryAsync(startDate, endDate, ct);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Gets aggregated inventory valuation figures: purchase vs retail valuations, potential margins, stock counts, and category breakdowns.
    /// </summary>
    [HttpGet("inventory/valuation")]
    [RequirePermission(Permissions.ReportsInventory)]
    public async Task<IActionResult> GetInventoryValuation(CancellationToken ct)
    {
        var result = await _reportService.GetInventoryValuationReportAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Gets real staff user directory and a live chronological activity audit trail (SuperAdmin only).
    /// </summary>
    [HttpGet("staff/activity")]
    [Authorize(Policy = "SuperAdmin")]
    [RequirePermission(Permissions.ReportsStaffAudit)]
    public async Task<IActionResult> GetStaffActivity([FromQuery] int limit = 50, CancellationToken ct = default)
    {
        var result = await _reportService.GetStaffActivityReportAsync(limit, ct);
        return StatusCode(result.StatusCode, result);
    }
}
