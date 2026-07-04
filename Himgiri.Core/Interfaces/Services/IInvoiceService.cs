using System;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IInvoiceService
{
    Task<JsonModel<InvoicePdfDto>> GenerateInvoiceAsync(Guid orderId, CancellationToken ct = default);
}

public record InvoicePdfDto(string InvoiceNumber, byte[] PdfContent, string ContentType);
