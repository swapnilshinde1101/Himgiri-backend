using System;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IInvoiceService
{
    Task<JsonModel<InvoicePdfDto>> GenerateInvoiceAsync(Guid orderId, CancellationToken ct = default);

    // enforceDispatchedStatus should be true only for anonymous/customer-facing access — admins and the
    // dispatch-notification job need to generate this pre-dispatch too, since it doubles as the warehouse
    // pick/pack slip printed *before* the order is marked Dispatched.
    Task<JsonModel<DeliveryChallanPdfDto>> GenerateDeliveryChallanAsync(Guid orderId, bool enforceDispatchedStatus = false, CancellationToken ct = default);
}

public record InvoicePdfDto(string InvoiceNumber, byte[] PdfContent, string ContentType);
public record DeliveryChallanPdfDto(string ChallanNumber, byte[] PdfContent, string ContentType);
