using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Himgiri.API.Controllers;

[Authorize]
public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;
    private readonly IConfiguration _config;

    public OrdersController(IOrderService orderService, IConfiguration config)
    {
        _orderService = orderService;
        _config = config;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken ct)
    {
        var result = await _orderService.CreateOrderAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetOrder(Guid id, CancellationToken ct)
    {
        var result = await _orderService.GetOrderByIdAsync(id, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetOrders([FromQuery] OrderQueryRequest request, CancellationToken ct)
    {
        var result = await _orderService.GetPagedOrdersAsync(request, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/status")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] OrderStatusDto request, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.UpdateOrderStatusAsync(id, request, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("{id:guid}/notes")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> AddNote(Guid id, [FromBody] AddOrderNoteRequest request, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.AddOrderNoteAsync(id, request, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/stockout")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> FlagStockOut(Guid id, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.FlagStockOutAsync(id, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPatch("{id:guid}/refund")]
    [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> ProcessRefund(Guid id, [FromBody] ProcessRefundRequest request, CancellationToken ct)
    {
        var adminName = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? 
                         User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? 
                         User.Identity?.Name ?? "Admin";

        var result = await _orderService.ProcessRefundAsync(id, request, adminName, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("export/csv")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> ExportCsv(CancellationToken ct)
    {
        var csvBytes = await _orderService.ExportOrdersToCsvAsync(ct);
        var filename = $"Orders_Export_{System.DateTime.UtcNow:yyyyMMdd_HHmmss}.csv";
        return File(csvBytes, "text/csv", filename);
    }

    [HttpGet("export/excel")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> ExportExcel(CancellationToken ct)
    {
        var xlsxBytes = await _orderService.ExportOrdersToExcelAsync(ct);
        var filename = $"Orders_Export_{System.DateTime.UtcNow:yyyyMMdd_HHmmss}.xlsx";
        return File(xlsxBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
    }

    [HttpGet("{id:guid}/invoice")]
    [AllowAnonymous]
    public async Task<IActionResult> DownloadInvoice(Guid id, [FromServices] IInvoiceService invoiceService, CancellationToken ct)
    {
        var result = await invoiceService.GenerateInvoiceAsync(id, ct);
        if (result.StatusCode != 200 || result.Data == null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return File(result.Data.PdfContent, result.Data.ContentType, $"Invoice_{result.Data.InvoiceNumber}.pdf");
    }

    [HttpGet("customers")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetCustomers(CancellationToken ct)
    {
        var result = await _orderService.GetCustomersAsync(ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("customers/{mobile}")]
    [Authorize(Policy = "AnyAdmin")]
    public async Task<IActionResult> GetCustomerOrders(string mobile, CancellationToken ct)
    {
        var result = await _orderService.GetOrdersByCustomerAsync(mobile, ct);
        return StatusCode(result.StatusCode, result);
    }


    [HttpGet("lookup")]
    [AllowAnonymous]
    public async Task<IActionResult> LookupOrders([FromQuery] string mobile, [FromQuery] string pincode, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(pincode))
        {
            return BadRequest(JsonModel<object>.Error("Mobile number and pincode are required."));
        }
        var result = await _orderService.LookupOrdersAsync(mobile, pincode, ct);
        return StatusCode(result.StatusCode, result);
    }
}
