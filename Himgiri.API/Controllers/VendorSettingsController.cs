using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Himgiri.API.Controllers;

[Authorize(Policy = "AnyAdmin")]
public class VendorSettingsController : BaseController
{
    private readonly HimgiriDbContext _db;

    public VendorSettingsController(HimgiriDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetSettings(CancellationToken ct)
    {
        var settings = await _db.VendorSettings
            .Include(s => s.State)
            .FirstOrDefaultAsync(ct);

        if (settings == null)
        {
            return NotFound(JsonModel<VendorSettingsDto>.Error("Vendor settings not initialized."));
        }

        var dto = new VendorSettingsDto(
            settings.Id,
            settings.CompanyName,
            settings.Gstin,
            settings.Address,
            settings.ContactEmail,
            settings.ContactPhone,
            settings.InvoicePrefix,
            settings.LastInvoiceNumber,
            settings.StateId,
            settings.State?.StateName,
            settings.DefaultLowStockThreshold
        );

        return Ok(JsonModel<VendorSettingsDto>.Success(dto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSettings([FromBody] UpdateVendorSettingsRequest request, CancellationToken ct)
    {
        if (request == null)
        {
            return BadRequest(JsonModel<bool>.Error("Invalid request body."));
        }

        var settings = await _db.VendorSettings.FirstOrDefaultAsync(ct);
        if (settings == null)
        {
            return NotFound(JsonModel<bool>.Error("Vendor settings not found."));
        }

        // Validate state settings if provided
        State? targetState = null;
        if (request.StateId.HasValue && request.StateId.Value != Guid.Empty)
        {
            targetState = await _db.States.FirstOrDefaultAsync(s => s.Id == request.StateId.Value, ct);
            if (targetState == null)
            {
                return BadRequest(JsonModel<bool>.Error("Selected state does not exist in system jurisdictions."));
            }
            if (!targetState.IsActive)
            {
                return BadRequest(JsonModel<bool>.Error("Selected state is inactive."));
            }
        }

        // Validate GSTIN matching first two digits of state GST code
        if (!string.IsNullOrWhiteSpace(request.Gstin))
        {
            var cleanedGstin = request.Gstin.Trim().ToUpper();
            
            // Allow PENDING placeholders to bypass matches, otherwise enforce GSTIN formats
            bool isPlaceholder = cleanedGstin.Contains("PENDING") || cleanedGstin.Contains("GSTIN_");
            if (!isPlaceholder)
            {
                if (cleanedGstin.Length != 15)
                {
                    return BadRequest(JsonModel<bool>.Error("GSTIN must be exactly 15 characters."));
                }
                if (targetState != null && cleanedGstin.Substring(0, 2) != targetState.GstStateCode)
                {
                    return BadRequest(JsonModel<bool>.Error($"GSTIN first two digits must match the selected state's GST prefix code '{targetState.GstStateCode}'."));
                }
            }
            settings.Gstin = cleanedGstin;
        }
        else
        {
            settings.Gstin = string.Empty;
        }

        settings.CompanyName = request.CompanyName?.Trim() ?? string.Empty;
        settings.Address = request.Address?.Trim() ?? string.Empty;
        settings.ContactEmail = request.ContactEmail?.Trim() ?? string.Empty;
        settings.ContactPhone = request.ContactPhone?.Trim() ?? string.Empty;
        settings.InvoicePrefix = request.InvoicePrefix?.Trim() ?? "HG";
        settings.StateId = request.StateId;
        settings.DefaultLowStockThreshold = request.DefaultLowStockThreshold;
        settings.UpdatedAt = DateTime.UtcNow;

        _db.VendorSettings.Update(settings);
        await _db.SaveChangesAsync(ct);

        return Ok(JsonModel<bool>.Success(true, "Vendor settings updated successfully."));
    }
}
