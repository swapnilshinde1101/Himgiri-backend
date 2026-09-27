using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Core.Helpers;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Hangfire;

namespace Himgiri.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly IItemRepository _itemRepo;
    private readonly IGradeRepository _gradeRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HimgiriDbContext _db;
    private readonly ITaxService _taxService;
    private readonly IExcelService _excelService;
    private readonly ICsvService _csvService;
    private readonly IConfiguration? _config;
    private readonly ILogger<OrderService>? _logger;
    private readonly IBackgroundJobClient? _backgroundJobClient;

    public OrderService(
        IOrderRepository orderRepo,
        IItemRepository itemRepo,
        IGradeRepository gradeRepo,
        IUnitOfWork unitOfWork,
        HimgiriDbContext db,
        ITaxService taxService,
        IExcelService excelService,
        ICsvService csvService,
        IConfiguration? config = null,
        ILogger<OrderService>? logger = null,
        IBackgroundJobClient? backgroundJobClient = null)
    {
        _orderRepo = orderRepo;
        _itemRepo = itemRepo;
        _gradeRepo = gradeRepo;
        _unitOfWork = unitOfWork;
        _db = db;
        _taxService = taxService;
        _excelService = excelService;
        _csvService = csvService;
        _config = config;
        _logger = logger;
        _backgroundJobClient = backgroundJobClient;
    }

    public async Task<JsonModel<OrderSummaryDto>> CreateOrderAsync(CreateOrderRequest request, CancellationToken ct = default)
    {
        // ── 1. Validate Customer Details ──
        if (string.IsNullOrWhiteSpace(request.CustomerName) || request.CustomerName.Trim().Length < 3 || request.CustomerName.Trim().Length > 100)
        {
            return JsonModel<OrderSummaryDto>.Error("Customer Name is required and must be between 3 and 100 characters.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.Email) || !IsValidEmail(request.Email))
        {
            return JsonModel<OrderSummaryDto>.Error("A valid Email address is required.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.Mobile) || request.Mobile.Length != 10 || !request.Mobile.All(char.IsDigit))
        {
            return JsonModel<OrderSummaryDto>.Error("Mobile number must be exactly 10 digits.", 400);
        }

        char firstChar = request.Mobile[0];
        if (firstChar != '6' && firstChar != '7' && firstChar != '8' && firstChar != '9')
        {
            return JsonModel<OrderSummaryDto>.Error("A valid Indian mobile number starting with 6, 7, 8, or 9 is required.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.AddressLine1))
        {
            return JsonModel<OrderSummaryDto>.Error("Address Line 1 is required.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.City))
        {
            return JsonModel<OrderSummaryDto>.Error("City is required.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.Pincode) || request.Pincode.Length != 6 || !request.Pincode.All(char.IsDigit))
        {
            return JsonModel<OrderSummaryDto>.Error("Pincode must be exactly 6 digits.", 400);
        }

        Grade? grade = null;
        if (request.GradeId.HasValue && request.GradeId.Value != Guid.Empty)
        {
            grade = await _gradeRepo.GetByIdAsync(request.GradeId.Value, ct);
            if (grade == null)
            {
                return JsonModel<OrderSummaryDto>.Error("Grade not found.", 404);
            }
            if (!grade.IsActive)
            {
                return JsonModel<OrderSummaryDto>.Error("Selected grade is inactive.", 400);
            }
        }

        if (request.Items == null || !request.Items.Any())
        {
            return JsonModel<OrderSummaryDto>.Error("Cart cannot be empty.", 400);
        }

        // Start Transaction
        await _unitOfWork.BeginTransactionAsync(ct);
        try
        {
            // Lock VendorSettings atomically
            var settings = await _orderRepo.GetVendorSettingsAsync(ct);
            if (settings == null)
            {
                return JsonModel<OrderSummaryDto>.Error("Vendor settings not initialized in system.", 500);
            }

            // ── Validate Customer & Seller States ──
            var customerState = await _db.States.FirstOrDefaultAsync(s => s.Id == request.CustomerStateId, ct);
            if (customerState == null)
            {
                return JsonModel<OrderSummaryDto>.Error("Selected Customer State not found.", 404);
            }
            if (!customerState.IsActive)
            {
                return JsonModel<OrderSummaryDto>.Error("Selected Customer State is inactive.", 400);
            }

            if (!settings.StateId.HasValue)
            {
                return JsonModel<OrderSummaryDto>.Error("Vendor State settings are not configured.", 500);
            }
            var sellerState = await _db.States.FirstOrDefaultAsync(s => s.Id == settings.StateId.Value, ct);
            if (sellerState == null)
            {
                return JsonModel<OrderSummaryDto>.Error("Vendor State not found.", 500);
            }

            // ── Validate GSTIN first 2 digits match state's GST code ──
            if (!string.IsNullOrWhiteSpace(request.CustomerGstin))
            {
                var cleanedGstin = request.CustomerGstin.Trim().ToUpper();
                if (cleanedGstin.Length != 15)
                {
                    return JsonModel<OrderSummaryDto>.Error("GSTIN must be exactly 15 characters long.", 400);
                }
                if (cleanedGstin.Substring(0, 2) != customerState.GstStateCode)
                {
                    return JsonModel<OrderSummaryDto>.Error($"GSTIN prefix '{cleanedGstin.Substring(0, 2)}' does not match the selected customer state code '{customerState.GstStateCode}'.", 400);
                }
            }

            if (!string.IsNullOrWhiteSpace(settings.Gstin))
            {
                var cleanedGstin = settings.Gstin.Trim().ToUpper();
                if (cleanedGstin.Length >= 2 && cleanedGstin.Substring(0, 2) != sellerState.GstStateCode)
                {
                    return JsonModel<OrderSummaryDto>.Error($"Vendor GSTIN prefix '{cleanedGstin.Substring(0, 2)}' does not match the selected vendor state code '{sellerState.GstStateCode}'.", 500);
                }
            }

            var supplyType = _taxService.DetermineSupplyType(sellerState.Id, customerState.Id);

            // ── 2. Validate Items & Stock (Aggregating duplicates for safety) ──
            var aggregatedItems = request.Items
                .GroupBy(i => new { i.ItemId, i.IsKitItem })
                .Select(g => new OrderItemRequest(g.Key.ItemId, g.Sum(i => i.Quantity), g.Key.IsKitItem))
                .ToList();

            var itemIds = aggregatedItems.Select(i => i.ItemId).Distinct().ToList();
            var dbItems = await _itemRepo.GetByIdsAsync(itemIds, ct);

            // Validate stock against TOTAL demand per physical item — the same item can
            // appear as both a mandatory kit item and a separate add-on in one order, so
            // this must be checked before the per-line loop below, not inside it (checking
            // each {ItemId, IsKitItem} group in isolation would miss combined over-demand).
            var totalQuantityByItem = aggregatedItems
                .GroupBy(i => i.ItemId)
                .ToDictionary(g => g.Key, g => g.Sum(i => i.Quantity));

            foreach (var (stockItemId, requestedQty) in totalQuantityByItem)
            {
                var stockItem = dbItems.FirstOrDefault(i => i.Id == stockItemId);
                if (stockItem != null && stockItem.StorageStatus == StorageStatus.InStock && requestedQty > stockItem.StockQty)
                {
                    return JsonModel<OrderSummaryDto>.Error(
                        $"Only {stockItem.StockQty} {stockItem.Unit} of '{stockItem.Name}' available in stock.", 400);
                }
            }

            var orderItemsList = new List<OrderItem>();
            decimal subTotal = 0m;
            decimal itemsGstSum = 0m;

            foreach (var itemReq in aggregatedItems)
            {
                var item = dbItems.FirstOrDefault(i => i.Id == itemReq.ItemId);
                if (item == null)
                {
                    return JsonModel<OrderSummaryDto>.Error($"Item with ID '{itemReq.ItemId}' not found.", 404);
                }

                if (!item.IsActive)
                {
                    return JsonModel<OrderSummaryDto>.Error($"Item '{item.Name}' is currently inactive.", 400);
                }

                if (itemReq.Quantity <= 0)
                {
                    return JsonModel<OrderSummaryDto>.Error($"Quantity for item '{item.Name}' must be greater than zero.", 400);
                }



                // ── 3. Resolve GstRate & Snapshot Item Data ──
                decimal unitPrice = item.Price;

                GstRate? resolvedGstRate = item.GstRate;
                if (resolvedGstRate == null)
                {
                    resolvedGstRate = item.Category?.DefaultGstRate;
                }

                if (resolvedGstRate == null)
                {
                    return JsonModel<OrderSummaryDto>.Error($"GST Rate not configured for item '{item.Name}' or its Category.", 400);
                }

                decimal gstPercent = resolvedGstRate.Rate;

                // ── 4. Calculate GST per line item ──
                decimal taxableAmount = unitPrice * itemReq.Quantity;
                var itemTaxResult = _taxService.CalculateTax(taxableAmount, gstPercent, 0m, supplyType);

                subTotal += itemTaxResult.BaseAmount;
                itemsGstSum += itemTaxResult.GstAmount;

                orderItemsList.Add(new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = item.Id,
                    ItemName = item.Name,
                    HsnCode = resolvedGstRate.HsnCode,
                    Quantity = itemReq.Quantity,
                    UnitPrice = unitPrice,
                    GstPercent = itemTaxResult.GstPercent,
                    CgstPercent = itemTaxResult.CgstPercent,
                    SgstPercent = itemTaxResult.SgstPercent,
                    IgstPercent = itemTaxResult.IgstPercent,
                    CessPercent = itemTaxResult.CessPercent,
                    BaseAmount = itemTaxResult.BaseAmount,
                    GstAmount = itemTaxResult.GstAmount,
                    CgstAmount = itemTaxResult.CgstAmount,
                    SgstAmount = itemTaxResult.SgstAmount,
                    IgstAmount = itemTaxResult.IgstAmount,
                    CessAmount = itemTaxResult.CessAmount,
                    SupplyType = supplyType,
                    LineTotal = itemTaxResult.TotalAmount,
                    IsKitItem = itemReq.IsKitItem
                });
            }

            // ── 5. Calculate Delivery Fee (Set to 0m permanently per instructions) ──
            decimal deliveryBase = 0m;
            decimal deliveryGst = 0m;
            decimal deliveryCgst = 0m;
            decimal deliverySgst = 0m;
            decimal deliveryIgst = 0m;

            // ── 6. Calculate Totals ──
            decimal totalGst = itemsGstSum + deliveryGst;
            decimal grandTotal = subTotal + totalGst + deliveryBase;

            // ── 7. Generate Invoice Number ──
            settings.LastInvoiceNumber += 1;
            string invoiceNumber = $"{settings.InvoicePrefix}-{DateTime.UtcNow.Year}-{settings.LastInvoiceNumber:D4}";
            _db.VendorSettings.Update(settings);

            // ── 8. Save Order ──
            var order = new Order
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = invoiceNumber,
                CustomerName = request.CustomerName.Trim(),
                Email = request.Email.Trim().ToLower(),
                Mobile = request.Mobile.Trim(),
                AddressLine1 = request.AddressLine1.Trim(),
                AddressLine2 = request.AddressLine2?.Trim() ?? string.Empty,
                City = request.City.Trim(),
                Pincode = request.Pincode.Trim(),
                GradeId = request.GradeId,
                GradeName = grade?.Name ?? "Not specified",
                CustomerGstin = request.CustomerGstin?.Trim().ToUpper() ?? string.Empty,

                SellerStateId = sellerState.Id,
                CustomerStateId = customerState.Id,

                // Snapshots
                SellerCompanyName = settings.CompanyName,
                SellerGstin = settings.Gstin,
                SellerAddress = settings.Address,
                SellerStateName = sellerState.StateName,
                SellerGstStateCode = sellerState.GstStateCode,

                CustomerStateName = customerState.StateName,
                CustomerGstStateCode = customerState.GstStateCode,

                PlaceOfSupply = customerState.StateName,
                PlaceOfSupplyCode = customerState.GstStateCode,

                SupplyType = supplyType,
                IsHomeDelivery = request.IsHomeDelivery,

                SubTotal = subTotal,
                TotalGst = totalGst,
                DeliveryFee = deliveryBase,
                DeliveryGst = deliveryGst,
                DeliveryCgstAmount = deliveryCgst,
                DeliverySgstAmount = deliverySgst,
                DeliveryIgstAmount = deliveryIgst,
                GrandTotal = grandTotal,
                Status = OrderStatus.Pending,
                PaymentStatus = PaymentStatus.Pending,
                IsRefunded = false,
                CreatedAt = DateTime.UtcNow,
                Items = orderItemsList
            };

            _orderRepo.Add(order);

            // Save changes and Commit transaction
            await _unitOfWork.CommitTransactionAsync(ct);

            var summary = new OrderSummaryDto(
                order.Id,
                order.InvoiceNumber,
                order.CustomerName,
                order.Mobile,
                order.Email,
                grade?.Name,
                order.IsHomeDelivery,
                order.GrandTotal,
                order.Status,
                order.PaymentStatus,
                order.CreatedAt
            );

            return JsonModel<OrderSummaryDto>.Success(summary, "Order created successfully.");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Unexpected error creating order for customer {CustomerName} ({Mobile})", request.CustomerName, request.Mobile);
            await _unitOfWork.RollbackTransactionAsync(ct);
            return JsonModel<OrderSummaryDto>.Error("Failed to create order due to an internal server error. Please try again.", 500);
        }
    }

    public async Task<JsonModel<OrderDetailDto>> GetOrderByIdAsync(Guid id, CancellationToken ct = default)
    {
        var order = await _orderRepo.GetByIdAsync(id, ct);
        if (order == null)
        {
            return JsonModel<OrderDetailDto>.Error("Order not found.", 404);
        }

        var dto = new OrderDetailDto(
            order.Id,
            order.InvoiceNumber,
            order.CustomerName,
            order.Email,
            order.Mobile,
            order.AddressLine1,
            order.AddressLine2,
            order.City,
            order.Pincode,
            order.GradeName,
            order.SubTotal,
            order.TotalGst,
            order.DeliveryFee,
            order.DeliveryGst,
            order.GrandTotal,
            order.Status,
            order.PaymentStatus,
            order.JodoPaymentId,
            order.AdminNotes,
            order.CreatedAt,
            (order.Items ?? Enumerable.Empty<OrderItem>()).Select(oi => new OrderItemDto(
                oi.ItemName,
                oi.HsnCode,
                oi.Quantity,
                oi.UnitPrice,
                oi.GstPercent,
                oi.GstAmount,
                oi.CgstAmount,
                oi.SgstAmount,
                oi.LineTotal,
                oi.IsKitItem
            )).ToList(),
            (order.StatusHistories ?? Enumerable.Empty<OrderStatusHistory>()).OrderBy(sh => sh.CreatedAt).Select(sh => new OrderStatusHistoryDto(
                sh.FromStatus.ToString(),
                sh.ToStatus.ToString(),
                sh.ChangedBy,
                sh.Note,
                sh.CreatedAt
            )).ToList()
        );

        return JsonModel<OrderDetailDto>.Success(dto);
    }

    public async Task<JsonModel<List<OrderSummaryDto>>> GetPagedOrdersAsync(OrderQueryRequest request, CancellationToken ct = default)
    {
        var (orders, total) = await _orderRepo.GetPagedAsync(request, ct);

        var dtos = orders.Select(o => new OrderSummaryDto(
            o.Id,
            o.InvoiceNumber,
            o.CustomerName,
            o.Mobile,
            o.Email,
            o.Grade?.Name,
            o.IsHomeDelivery,
            o.GrandTotal,
            o.Status,
            o.PaymentStatus,
            o.CreatedAt
        )).ToList();

        return new JsonModel<List<OrderSummaryDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<bool>> UpdateOrderStatusAsync(Guid id, OrderStatusDto request, string changedBy, CancellationToken ct = default)
    {
        var order = await _orderRepo.GetByIdAsync(id, ct);
        if (order == null)
        {
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        var fromStatus = order.Status;
        var toStatus = request.ToStatus;

        // Validation mapping rules
        bool isValid = false;
        if (toStatus == OrderStatus.StockOut || toStatus == OrderStatus.Refunded)
        {
            isValid = true;
        }
        else if (fromStatus == OrderStatus.Pending && toStatus == OrderStatus.Confirmed)
        {
            isValid = true;
        }
        else if (fromStatus == OrderStatus.Confirmed && toStatus == OrderStatus.Packed)
        {
            isValid = true;
        }
        else if (fromStatus == OrderStatus.Packed && toStatus == OrderStatus.Dispatched)
        {
            isValid = true;
        }
        else if (fromStatus == OrderStatus.Dispatched && toStatus == OrderStatus.Delivered)
        {
            isValid = true;
        }

        if (!isValid)
        {
            return JsonModel<bool>.Error($"Invalid order status transition from {fromStatus} to {toStatus}.", 400);
        }

        // Deduct stock when order is dispatched
        if (fromStatus == OrderStatus.Packed && toStatus == OrderStatus.Dispatched)
        {
            foreach (var orderItem in order.Items)
            {
                var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == orderItem.ItemId && !i.IsDeleted, ct);
                if (item != null && item.StorageStatus == StorageStatus.InStock)
                {
                    int oldQty = item.StockQty;
                    item.StockQty -= orderItem.Quantity;
                    if (item.StockQty < 0)
                    {
                        item.StockQty = 0;
                    }
                    item.UpdatedAt = DateTime.UtcNow;

                    var log = new StockLog
                    {
                        Id = Guid.NewGuid(),
                        ItemId = item.Id,
                        OldQty = oldQty,
                        NewQty = item.StockQty,
                        ChangedBy = changedBy,
                        Reason = "Order Dispatched",
                        Note = order.InvoiceNumber,
                        CreatedAt = DateTime.UtcNow
                    };

                    _db.Items.Update(item);
                    _db.StockLogs.Add(log);
                }
            }
        }

        order.Status = toStatus;
        order.UpdatedAt = DateTime.UtcNow;

        var history = new OrderStatusHistory
        {
            OrderId = order.Id,
            FromStatus = fromStatus,
            ToStatus = toStatus,
            ChangedBy = changedBy,
            Note = request.Note,
            CreatedAt = DateTime.UtcNow
        };

        _orderRepo.Update(order);
        _orderRepo.AddStatusHistory(history);

        try
        {
            await _unitOfWork.CommitAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            return JsonModel<bool>.Error("Stock levels changed concurrently while dispatching this order. Please retry.", 409);
        }

        // Enqueue automated notifications in background
        if (toStatus == OrderStatus.Dispatched)
        {
            try
            {
                _backgroundJobClient?.Enqueue<IOrderNotificationService>(s => s.SendOrderDispatchedAsync(order.Id, CancellationToken.None));
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Failed to enqueue dispatch notification for order {OrderId}", order.Id);
            }
        }
        else if (toStatus == OrderStatus.Cancelled)
        {
            try
            {
                _backgroundJobClient?.Enqueue<IOrderNotificationService>(s => s.SendOrderCancelledAsync(order.Id, request.Note ?? "Order Cancelled", CancellationToken.None));
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Failed to enqueue cancellation notification for order {OrderId}", order.Id);
            }
        }

        return JsonModel<bool>.Success(true, "Order status updated successfully.");
    }

    public async Task<JsonModel<BulkOrderStatusResultDto>> BulkUpdateOrderStatusAsync(
        BulkOrderStatusRequest request, 
        string changedBy, 
        CancellationToken ct = default)
    {
        if (request.OrderIds == null || !request.OrderIds.Any())
        {
            return JsonModel<BulkOrderStatusResultDto>.Error("No order IDs provided.", 400);
        }

        if (request.OrderIds.Count > 100)
        {
            return JsonModel<BulkOrderStatusResultDto>.Error("Maximum 100 orders can be updated in a single bulk operation.", 400);
        }

        var distinctIds = request.OrderIds.Distinct().ToList();
        var toStatus = request.ToStatus;

        var updatedInvoices = new List<string>();
        var skippedReasons = new List<string>();

        await _unitOfWork.BeginTransactionAsync(ct);
        try
        {
            var orders = await _db.Orders
                .Include(o => o.Items)
                .Where(o => distinctIds.Contains(o.Id) && !o.IsDeleted)
                .ToListAsync(ct);

            foreach (var orderId in distinctIds)
            {
                var order = orders.FirstOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    skippedReasons.Add($"Order {orderId}: Not found.");
                    continue;
                }

                var fromStatus = order.Status;

                // Validate transition
                bool isValid = false;
                if (fromStatus == OrderStatus.Confirmed && toStatus == OrderStatus.Packed)
                {
                    isValid = true;
                }
                else if (fromStatus == OrderStatus.Packed && toStatus == OrderStatus.Dispatched)
                {
                    isValid = true;
                }
                else if (fromStatus == OrderStatus.Dispatched && toStatus == OrderStatus.Delivered)
                {
                    isValid = true;
                }
                else if (toStatus == OrderStatus.StockOut)
                {
                    isValid = fromStatus == OrderStatus.Confirmed || fromStatus == OrderStatus.Packed;
                }

                if (!isValid)
                {
                    skippedReasons.Add($"Invoice {order.InvoiceNumber}: Cannot transition from {fromStatus} to {toStatus}.");
                    continue;
                }

                // If moving to Dispatched, deduct stock
                if (fromStatus == OrderStatus.Packed && toStatus == OrderStatus.Dispatched)
                {
                    foreach (var orderItem in order.Items)
                    {
                        var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == orderItem.ItemId && !i.IsDeleted, ct);
                        if (item != null && item.StorageStatus == StorageStatus.InStock)
                        {
                            int oldQty = item.StockQty;
                            item.StockQty -= orderItem.Quantity;
                            if (item.StockQty < 0) item.StockQty = 0;
                            item.UpdatedAt = DateTime.UtcNow;

                            var log = new StockLog
                            {
                                Id = Guid.NewGuid(),
                                ItemId = item.Id,
                                OldQty = oldQty,
                                NewQty = item.StockQty,
                                ChangedBy = changedBy,
                                Reason = "Bulk Order Dispatched",
                                Note = $"Bulk dispatch: {order.InvoiceNumber}",
                                CreatedAt = DateTime.UtcNow
                            };

                            _db.Items.Update(item);
                            _db.StockLogs.Add(log);
                        }
                    }
                }

                order.Status = toStatus;
                order.UpdatedAt = DateTime.UtcNow;

                var history = new OrderStatusHistory
                {
                    OrderId = order.Id,
                    FromStatus = fromStatus,
                    ToStatus = toStatus,
                    ChangedBy = changedBy,
                    Note = request.Note ?? $"Bulk update to {toStatus}",
                    CreatedAt = DateTime.UtcNow
                };

                _orderRepo.Update(order);
                _orderRepo.AddStatusHistory(history);
                updatedInvoices.Add(order.InvoiceNumber);
            }

            await _unitOfWork.CommitTransactionAsync(ct);

            var result = new BulkOrderStatusResultDto(
                updatedInvoices.Count,
                skippedReasons.Count,
                updatedInvoices,
                skippedReasons
            );

            return JsonModel<BulkOrderStatusResultDto>.Success(
                result, 
                $"Successfully updated {updatedInvoices.Count} order(s). {skippedReasons.Count} skipped."
            );
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to bulk update order statuses to {ToStatus}", toStatus);
            await _unitOfWork.RollbackTransactionAsync(ct);
            return JsonModel<BulkOrderStatusResultDto>.Error($"Bulk status update failed: {ex.Message}", 500);
        }
    }

    public async Task<JsonModel<bool>> AddOrderNoteAsync(Guid id, AddOrderNoteRequest request, string changedBy, CancellationToken ct = default)
    {
        var order = await _orderRepo.GetByIdAsync(id, ct);
        if (order == null)
        {
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        var timestamp = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm");
        var newNote = $"[{changedBy} - {timestamp}] {request.Note}";

        if (string.IsNullOrEmpty(order.AdminNotes))
        {
            order.AdminNotes = newNote;
        }
        else
        {
            order.AdminNotes = $"{order.AdminNotes}\n{newNote}";
        }

        order.UpdatedAt = DateTime.UtcNow;
        _orderRepo.Update(order);

        await _unitOfWork.CommitAsync(ct);
        return JsonModel<bool>.Success(true, "Note added successfully.");
    }

    public async Task<JsonModel<bool>> FlagStockOutAsync(Guid id, string changedBy, CancellationToken ct = default)
    {
        var order = await _orderRepo.GetByIdAsync(id, ct);
        if (order == null)
        {
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        return await UpdateOrderStatusAsync(id, new OrderStatusDto(OrderStatus.StockOut, "Flagged as Stock-Out by administrator."), changedBy, ct);
    }

    public async Task<JsonModel<bool>> ProcessRefundAsync(Guid id, ProcessRefundRequest request, string changedBy, CancellationToken ct = default)
    {
        var order = await _orderRepo.GetByIdAsync(id, ct);
        if (order == null)
        {
            return JsonModel<bool>.Error("Order not found.", 404);
        }

        // If order had already been dispatched or delivered (where stock was deducted), restore stock
        if (order.Status == OrderStatus.Dispatched || order.Status == OrderStatus.Delivered)
        {
            foreach (var orderItem in order.Items)
            {
                var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == orderItem.ItemId && !i.IsDeleted, ct);
                if (item != null && item.StorageStatus == StorageStatus.InStock)
                {
                    int oldQty = item.StockQty;
                    item.StockQty += orderItem.Quantity;
                    item.UpdatedAt = DateTime.UtcNow;

                    var log = new StockLog
                    {
                        Id = Guid.NewGuid(),
                        ItemId = item.Id,
                        OldQty = oldQty,
                        NewQty = item.StockQty,
                        ChangedBy = changedBy,
                        Reason = "Refund / Restock",
                        Note = $"Restocked from refunded order {order.InvoiceNumber}",
                        CreatedAt = DateTime.UtcNow
                    };

                    _db.Items.Update(item);
                    _db.StockLogs.Add(log);
                }
            }
        }

        order.IsRefunded = true;
        order.RefundReason = request.Reason;
        _orderRepo.Update(order);

        return await UpdateOrderStatusAsync(
            id, 
            new OrderStatusDto(OrderStatus.Refunded, $"Refund processed. Reason: {request.Reason}. (Note: Verify settlement/gateway status on Jodo Merchant Portal)."), 
            changedBy, 
            ct);
    }

    public async Task<byte[]> ExportOrdersToCsvAsync(DateTime? startDate = null, DateTime? endDate = null, CancellationToken ct = default)
    {
        var query = _db.Orders
            .Include(o => o.Grade)
            .Where(o => o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted);

        if (startDate.HasValue)
        {
            var utcStart = DateTime.SpecifyKind(startDate.Value, DateTimeKind.Utc);
            query = query.Where(o => o.CreatedAt >= utcStart);
        }

        if (endDate.HasValue)
        {
            var utcEnd = DateTime.SpecifyKind(endDate.Value, DateTimeKind.Utc);
            query = query.Where(o => o.CreatedAt <= utcEnd);
        }

        var orders = await query
            .OrderByDescending(o => o.CreatedAt)
            .Take(5000) // Safety cap: prevents an unbounded full-table export when no date range is given
            .ToListAsync(ct);

        var exportData = orders.Select(o => new OrderExportRow
        {
            InvoiceNumber = o.InvoiceNumber,
            CustomerName = o.CustomerName,
            Mobile = o.Mobile,
            Email = o.Email,
            Grade = o.GradeName,
            GrandTotal = o.GrandTotal,
            Status = o.Status.ToString(),
            CreatedAt = o.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            Address = $"{o.AddressLine1} {o.AddressLine2}, {o.City} - {o.Pincode}"
        }).ToList();

        return _csvService.ExportToCsv(exportData);
    }

    public async Task<byte[]> ExportOrdersToExcelAsync(DateTime? startDate = null, DateTime? endDate = null, CancellationToken ct = default)
    {
        var query = _db.Orders
            .Include(o => o.Grade)
            .Where(o => o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted);

        if (startDate.HasValue)
        {
            var utcStart = DateTime.SpecifyKind(startDate.Value, DateTimeKind.Utc);
            query = query.Where(o => o.CreatedAt >= utcStart);
        }

        if (endDate.HasValue)
        {
            var utcEnd = DateTime.SpecifyKind(endDate.Value, DateTimeKind.Utc);
            query = query.Where(o => o.CreatedAt <= utcEnd);
        }

        var orders = await query
            .OrderByDescending(o => o.CreatedAt)
            .Take(5000) // Safety cap: prevents an unbounded full-table export when no date range is given
            .ToListAsync(ct);

        var exportData = orders.Select(o => new OrderExportRow
        {
            InvoiceNumber = o.InvoiceNumber,
            CustomerName = o.CustomerName,
            Mobile = o.Mobile,
            Email = o.Email,
            Grade = o.GradeName,
            GrandTotal = o.GrandTotal,
            Status = o.Status.ToString(),
            CreatedAt = o.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            Address = $"{o.AddressLine1} {o.AddressLine2}, {o.City} - {o.Pincode}"
        }).ToList();

        return _excelService.ExportToExcel(exportData, "Orders");
    }

    public async Task CancelStalePendingOrdersAsync(CancellationToken ct = default)
    {
        var cutoff = DateTime.UtcNow.AddDays(-2); // 48 hours ago
        var staleOrders = await _db.Orders
            .Where(o => o.Status == OrderStatus.Pending &&
                        o.PaymentStatus == PaymentStatus.Pending &&
                        o.CreatedAt < cutoff &&
                        !o.IsDeleted)
            .ToListAsync(ct);

        if (!staleOrders.Any())
        {
            return;
        }

        foreach (var order in staleOrders)
        {
            order.Status = OrderStatus.Cancelled;
            order.UpdatedAt = DateTime.UtcNow;

            var history = new OrderStatusHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                FromStatus = OrderStatus.Pending,
                ToStatus = OrderStatus.Cancelled,
                ChangedBy = "Hangfire System Scheduler",
                Note = "Cancelled automatically due to payment timeout (48 hours).",
                CreatedAt = DateTime.UtcNow
            };

            _db.Orders.Update(order);
            _db.OrderStatusHistories.Add(history);
        }

        await _db.SaveChangesAsync(ct);
    }

    public async Task<JsonModel<List<CustomerSummaryDto>>> GetCustomersAsync(CancellationToken ct = default)
    {
        var customers = await _orderRepo.GetUniqueCustomersAsync(ct);
        return JsonModel<List<CustomerSummaryDto>>.Success(customers);
    }

    public async Task<JsonModel<List<OrderSummaryDto>>> GetOrdersByCustomerAsync(string mobile, CancellationToken ct = default)
    {
        var orders = await _orderRepo.GetOrdersByCustomerMobileAsync(mobile, ct);
        var dtos = orders.Select(o => new OrderSummaryDto(
            o.Id,
            o.InvoiceNumber,
            o.CustomerName,
            o.Mobile,
            o.Email,
            o.Grade?.Name,
            o.IsHomeDelivery,
            o.GrandTotal,
            o.Status,
            o.PaymentStatus,
            o.CreatedAt
        )).ToList();

        return JsonModel<List<OrderSummaryDto>>.Success(dtos);
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public async Task<JsonModel<List<OrderLookupDto>>> LookupOrdersAsync(string mobile, string pincode, CancellationToken ct)
    {
        var cleanMobile = mobile.Trim();
        var cleanPincode = pincode.Trim();

        var orders = await _db.Orders
            .Where(o => o.Mobile == cleanMobile && o.Pincode == cleanPincode && !o.IsDeleted)
            .OrderByDescending(o => o.CreatedAt)
            .Select(o => new OrderLookupDto
            {
                Id = o.Id,
                InvoiceNumber = o.InvoiceNumber,
                CustomerName = o.CustomerName,
                GrandTotal = o.GrandTotal,
                Status = o.Status.ToString(),
                PaymentStatus = o.PaymentStatus.ToString(),
                CreatedAt = o.CreatedAt
            })
            .ToListAsync(ct);

        if (orders.Count == 0)
        {
            return JsonModel<List<OrderLookupDto>>.Error("No orders found matching the mobile number and pincode.", 404);
        }

        return JsonModel<List<OrderLookupDto>>.Success(orders);
    }

    public async Task<JsonModel<bool>> ConfirmPaymentAsync(Guid orderId, string transactionId, CancellationToken ct = default)
    {
        using var transaction = await _db.Database.BeginTransactionAsync(ct);
        try
        {
            var orderExists = await _db.Orders.AnyAsync(o => o.Id == orderId && !o.IsDeleted, ct);
            if (!orderExists)
            {
                await transaction.RollbackAsync(ct);
                return JsonModel<bool>.Error("Order not found.", 404);
            }

            // Atomic conditional update: the WHERE clause is re-checked against committed
            // data by the DB itself, so two concurrent webhook deliveries for the same order
            // can't both win the race (Order has no in-app concurrency token to rely on instead).
            var rowsAffected = await _db.Orders
                .Where(o => o.Id == orderId && !o.IsDeleted
                         && o.PaymentStatus != PaymentStatus.Success
                         && o.Status != OrderStatus.Cancelled)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(o => o.Status, OrderStatus.Confirmed)
                    .SetProperty(o => o.PaymentStatus, PaymentStatus.Success)
                    .SetProperty(o => o.JodoPaymentId, transactionId)
                    .SetProperty(o => o.UpdatedAt, DateTime.UtcNow), ct);

            if (rowsAffected == 0)
            {
                var currentStatus = await _db.Orders
                    .Where(o => o.Id == orderId)
                    .Select(o => o.Status)
                    .FirstOrDefaultAsync(ct);

                await transaction.CommitAsync(ct);

                if (currentStatus == OrderStatus.Cancelled)
                {
                    return JsonModel<bool>.Error(
                        "This order was already cancelled (payment timeout). Payment received after cancellation requires manual review.",
                        409);
                }

                return JsonModel<bool>.Success(true, "Payment already processed.");
            }

            _db.OrderStatusHistories.Add(new OrderStatusHistory
            {
                OrderId = orderId,
                FromStatus = OrderStatus.Pending,
                ToStatus = OrderStatus.Confirmed,
                ChangedBy = "Payment Gateway Webhook",
                Note = "Payment successful. Order Confirmed.",
                CreatedAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            // Enqueue automated order confirmation & invoice notification in background
            try
            {
                _backgroundJobClient?.Enqueue<IOrderNotificationService>(s => s.SendOrderConfirmationAsync(orderId, CancellationToken.None));
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Failed to enqueue order confirmation notification for order {OrderId}", orderId);
            }

            return JsonModel<bool>.Success(true, "Payment processed. Order Confirmed.");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Payment confirmation failed for OrderId {OrderId} with TransactionId {TransactionId}", orderId, transactionId);
            await transaction.RollbackAsync(ct);
            return JsonModel<bool>.Error("Payment confirmation failed due to an internal server error.", 500);
        }
    }

    public async Task<bool> VerifyOrderAccessAsync(Guid id, string mobile, string pincode, CancellationToken ct = default)
    {
        var cleanMobile = mobile.Trim();
        var cleanPincode = pincode.Trim();
        return await _db.Orders.AnyAsync(o => o.Id == id && o.Mobile == cleanMobile && o.Pincode == cleanPincode && !o.IsDeleted, ct);
    }

    public async Task<Himgiri.Core.Entities.Order?> GetOrderForPaymentAsync(Guid orderId, CancellationToken ct = default)
    {
        return await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);
    }

    public async Task SaveJodoOrderIdAsync(Guid orderId, string jodoOrderId, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId, ct);

        if (order != null)
        {
            order.JodoPaymentId = jodoOrderId;
            order.UpdatedAt = DateTime.UtcNow;
            _db.Orders.Update(order);
            await _db.SaveChangesAsync(ct);
        }
    }

    public async Task<JsonModel<bool>> ConfirmPaymentByInvoiceAsync(
        string invoiceNumber,
        string jodoOrderId,
        CancellationToken ct = default)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(
                o => o.InvoiceNumber == invoiceNumber && !o.IsDeleted, ct);

        if (order == null)
            return JsonModel<bool>.Error("Order not found.", 404);

        if (order.PaymentStatus == PaymentStatus.Success)
            return JsonModel<bool>.Success(true, "Already processed.");

        return await ConfirmPaymentAsync(order.Id, jodoOrderId, ct);
    }

    public async Task<JsonModel<OrderLookupDto>> GetOrderLookupAsync(
        Guid orderId,
        CancellationToken ct = default)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
            return JsonModel<OrderLookupDto>.Error("Order not found.", 404);

        var dto = new OrderLookupDto
        {
            Id = order.Id,
            InvoiceNumber = order.InvoiceNumber,
            CustomerName = order.CustomerName,
            Email = order.Email,
            Mobile = order.Mobile,
            AddressLine1 = order.AddressLine1,
            AddressLine2 = order.AddressLine2,
            City = order.City,
            Pincode = order.Pincode,
            GrandTotal = order.GrandTotal,
            Status = order.Status.ToString(),
            PaymentStatus = order.PaymentStatus.ToString(),
            IsHomeDelivery = order.IsHomeDelivery,
            Items = order.Items.Select(i => new OrderLookupItemDto(
                i.ItemId,
                i.ItemName,
                i.Quantity,
                i.LineTotal,
                i.IsKitItem
            )).ToList(),
            CreatedAt = order.CreatedAt
        };

        return JsonModel<OrderLookupDto>.Success(dto);
    }

    // Order-lookup tokens are valid for 30 days — long enough for a customer to revisit
    // their order confirmation/tracking link, short enough that a leaked URL (browser
    // history, referrer to Jodo's hosted payment page) doesn't grant permanent PII access.
    private static readonly TimeSpan OrderAccessTokenLifetime = TimeSpan.FromDays(30);

    public string GenerateOrderAccessToken(Guid orderId)
    {
        var expiryUnix = DateTimeOffset.UtcNow.Add(OrderAccessTokenLifetime).ToUnixTimeSeconds();
        var signature = ComputeOrderAccessSignature(orderId, expiryUnix);
        return $"{expiryUnix}.{signature}";
    }

    public bool VerifyOrderAccessToken(Guid orderId, string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return false;

        var parts = token.Trim().Split('.', 2);
        if (parts.Length != 2) return false;
        if (!long.TryParse(parts[0], out var expiryUnix)) return false;
        if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > expiryUnix) return false;

        var expectedSignature = ComputeOrderAccessSignature(orderId, expiryUnix);
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expectedSignature),
            Encoding.UTF8.GetBytes(parts[1].Trim().ToLowerInvariant())
        );
    }

    private string ComputeOrderAccessSignature(Guid orderId, long expiryUnix)
    {
        var secret = _config?["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes($"order_lookup_{orderId}_{expiryUnix}"));
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}
