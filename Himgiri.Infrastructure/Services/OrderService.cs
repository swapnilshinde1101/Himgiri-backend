using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Core.DTOs;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Himgiri.Core.Helpers;
using System.Text;

namespace Himgiri.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly IItemRepository _itemRepo;
    private readonly IGradeRepository _gradeRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HimgiriDbContext _db;
    private readonly ITaxService _taxService;

    public OrderService(
        IOrderRepository orderRepo,
        IItemRepository itemRepo,
        IGradeRepository gradeRepo,
        IUnitOfWork unitOfWork,
        HimgiriDbContext db,
        ITaxService taxService)
    {
        _orderRepo = orderRepo;
        _itemRepo = itemRepo;
        _gradeRepo = gradeRepo;
        _unitOfWork = unitOfWork;
        _db = db;
        _taxService = taxService;
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
                .GroupBy(i => i.ItemId)
                .Select(g => new OrderItemRequest(g.Key, g.Sum(i => i.Quantity)))
                .ToList();

            var itemIds = aggregatedItems.Select(i => i.ItemId).Distinct().ToList();
            var dbItems = await _itemRepo.GetByIdsAsync(itemIds, ct);

            var orderItemsList = new List<OrderItem>();
            decimal subTotal = 0m;
            decimal itemsGstSum = 0m;
            bool hasInStockItem = false;

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

                // Check stock for InStock items
                if (item.StorageStatus == StorageStatus.InStock)
                {
                    hasInStockItem = true;
                    if (item.StockQty < itemReq.Quantity)
                    {
                        return JsonModel<OrderSummaryDto>.Error($"Insufficient stock for {item.Name}. Available: {item.StockQty}, Requested: {itemReq.Quantity}", 400);
                    }
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
                var itemTaxResult = _taxService.CalculateTax(taxableAmount, gstPercent, 0m, supplyType, customerState.IsUnionTerritory);

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
                    LineTotal = itemTaxResult.TotalAmount
                });
            }

            // ── 5. Calculate Delivery Fee ──
            bool chargedDelivery = request.IncludeDelivery && hasInStockItem;
            decimal deliveryBase = 0m;
            decimal deliveryGst = 0m;
            decimal deliveryCgst = 0m;
            decimal deliverySgst = 0m;
            decimal deliveryIgst = 0m;

            if (chargedDelivery)
            {
                var deliveryCategory = await _db.ItemCategories
                    .Include(c => c.DefaultGstRate)
                    .FirstOrDefaultAsync(c => c.Name == "Delivery Fee", ct);

                decimal deliveryGstPercent = deliveryCategory?.DefaultGstRate?.Rate ?? 18m;
                // Calculate delivery base price dynamically from 250 inclusive total: Base = 250 / (1 + Rate / 100)
                decimal calculatedDeliveryBase = MoneyHelper.Round(250m / (1m + deliveryGstPercent / 100m));

                var deliveryTaxResult = _taxService.CalculateTax(calculatedDeliveryBase, deliveryGstPercent, 0m, supplyType, customerState.IsUnionTerritory);
                deliveryBase = deliveryTaxResult.BaseAmount;
                deliveryGst = deliveryTaxResult.GstAmount;
                deliveryCgst = deliveryTaxResult.CgstAmount;
                deliverySgst = deliveryTaxResult.SgstAmount;
                deliveryIgst = deliveryTaxResult.IgstAmount;
            }

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
                order.GrandTotal,
                order.Status,
                order.PaymentStatus,
                order.CreatedAt
            );

            return JsonModel<OrderSummaryDto>.Success(summary, "Order created successfully.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(ct);
            return JsonModel<OrderSummaryDto>.Error($"Failed to create order: {ex.Message}");
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
            order.Items.Select(oi => new OrderItemDto(
                oi.ItemName,
                oi.HsnCode,
                oi.Quantity,
                oi.UnitPrice,
                oi.GstPercent,
                oi.GstAmount,
                oi.CgstAmount,
                oi.SgstAmount,
                oi.LineTotal
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

        await _unitOfWork.CommitAsync(ct);
        return JsonModel<bool>.Success(true, "Order status updated successfully.");
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

        order.IsRefunded = true;
        order.RefundReason = request.Reason;
        _orderRepo.Update(order);

        return await UpdateOrderStatusAsync(id, new OrderStatusDto(OrderStatus.Refunded, $"Refund processed. Reason: {request.Reason}"), changedBy, ct);
    }

    public async Task<byte[]> ExportOrdersToCsvAsync(CancellationToken ct = default)
    {
        var orders = await _db.Orders
            .Include(o => o.Grade)
            .Where(o => o.PaymentStatus == PaymentStatus.Success && !o.IsDeleted)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync(ct);

        var csv = new StringBuilder();
        csv.AppendLine("Invoice No,Customer,Mobile,Email,Grade,Grand Total,Status,Created At,Address");

        foreach (var o in orders)
        {
            var address = $"\"{o.AddressLine1} {o.AddressLine2}, {o.City} - {o.Pincode}\"".Replace("\n", " ").Replace("\r", " ");
            csv.AppendLine($"{o.InvoiceNumber},{o.CustomerName},{o.Mobile},{o.Email},{o.GradeName},{o.GrandTotal},{o.Status},{o.CreatedAt},{address}");
        }

        return Encoding.UTF8.GetBytes(csv.ToString());
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

    public async Task<JsonModel<bool>> ConfirmPaymentAsync(Guid orderId, string transactionId, CancellationToken ct = default)
    {
        int retries = 3;
        while (retries > 0)
        {
            using var transaction = await _db.Database.BeginTransactionAsync(ct);
            try
            {
                // load order
                var order = await _db.Orders
                    .Include(o => o.Items)
                    .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);
                
                if (order == null)
                {
                    await transaction.RollbackAsync(ct);
                    return JsonModel<bool>.Error("Order not found.", 404);
                }

                if (order.PaymentStatus == PaymentStatus.Success)
                {
                    await transaction.RollbackAsync(ct);
                    return JsonModel<bool>.Success(true, "Payment already processed.");
                }

                // Verify stock and deduct
                bool sufficientStock = true;
                string stockOutMessage = "";

                foreach (var itemReq in order.Items)
                {
                    // Reload item to get freshest value from database and ensure EF tracks its concurrency token properly
                    var item = await _db.Items
                        .FirstOrDefaultAsync(i => i.Id == itemReq.ItemId && !i.IsDeleted, ct);
                    
                    if (item == null)
                    {
                        sufficientStock = false;
                        stockOutMessage = $"Item '{itemReq.ItemName}' no longer exists in the system.";
                        break;
                    }

                    if (item.StorageStatus == StorageStatus.InStock)
                    {
                        if (item.StockQty < itemReq.Quantity)
                        {
                            sufficientStock = false;
                            stockOutMessage = $"Insufficient stock for '{item.Name}'. Available: {item.StockQty}, Requested: {itemReq.Quantity}";
                            break;
                        }
                    }
                }

                if (!sufficientStock)
                {
                    // Update order status to StockOut
                    order.Status = OrderStatus.StockOut;
                    order.PaymentStatus = PaymentStatus.Success;
                    order.JodoPaymentId = transactionId;
                    order.UpdatedAt = DateTime.UtcNow;
                    order.AdminNotes = string.IsNullOrEmpty(order.AdminNotes)
                        ? $"[System - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] Payment succeeded but stock-out occurred. Reason: {stockOutMessage}"
                        : $"{order.AdminNotes}\n[System - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] Payment succeeded but stock-out occurred. Reason: {stockOutMessage}";

                    var history = new OrderStatusHistory
                    {
                        OrderId = order.Id,
                        FromStatus = OrderStatus.Pending,
                        ToStatus = OrderStatus.StockOut,
                        ChangedBy = "Payment Gateway Webhook",
                        Note = $"Payment succeeded but stock-out occurred: {stockOutMessage}",
                        CreatedAt = DateTime.UtcNow
                    };

                    _db.Orders.Update(order);
                    _db.OrderStatusHistories.Add(history);

                    await _db.SaveChangesAsync(ct);
                    await transaction.CommitAsync(ct);
                    return JsonModel<bool>.Success(true, $"Payment processed. Order flagged as Stock-Out due to: {stockOutMessage}");
                }

                // If sufficient stock, deduct stock and update order
                foreach (var itemReq in order.Items)
                {
                    var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == itemReq.ItemId && !i.IsDeleted, ct);
                    if (item != null && item.StorageStatus == StorageStatus.InStock)
                    {
                        int oldQty = item.StockQty;
                        item.StockQty -= itemReq.Quantity;
                        item.UpdatedAt = DateTime.UtcNow;
                        
                        var log = new StockLog
                        {
                            Id = Guid.NewGuid(),
                            ItemId = item.Id,
                            OldQty = oldQty,
                            NewQty = item.StockQty,
                            ChangedBy = "Payment Gateway Webhook",
                            Reason = "Order Placed",
                            CreatedAt = DateTime.UtcNow
                        };

                        _db.Items.Update(item);
                        _db.StockLogs.Add(log);
                    }
                }

                order.Status = OrderStatus.Confirmed;
                order.PaymentStatus = PaymentStatus.Success;
                order.JodoPaymentId = transactionId;
                order.UpdatedAt = DateTime.UtcNow;

                var confirmHistory = new OrderStatusHistory
                {
                    OrderId = order.Id,
                    FromStatus = OrderStatus.Pending,
                    ToStatus = OrderStatus.Confirmed,
                    ChangedBy = "Payment Gateway Webhook",
                    Note = "Payment successful. Order Confirmed.",
                    CreatedAt = DateTime.UtcNow
                };

                _db.Orders.Update(order);
                _db.OrderStatusHistories.Add(confirmHistory);

                await _db.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);

                return JsonModel<bool>.Success(true, "Payment confirmed and stock deducted successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                await transaction.RollbackAsync(ct);
                retries--;
                if (retries == 0)
                {
                    return JsonModel<bool>.Error("Concurrency collision during payment processing. Please retry.", 409);
                }
                // Small random backoff before retrying
                await Task.Delay(new Random().Next(50, 150), ct);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                return JsonModel<bool>.Error($"Payment confirmation failed: {ex.Message}");
            }
        }
        return JsonModel<bool>.Error("Payment confirmation failed due to persistent concurrency conflicts.", 409);
    }
}
