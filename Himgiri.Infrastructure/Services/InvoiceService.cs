using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Himgiri.Infrastructure.Services;

public class InvoiceService : IInvoiceService
{
    private readonly HimgiriDbContext _db;

    static InvoiceService()
    {
        // QuestPDF license configuration
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public InvoiceService(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task<JsonModel<InvoicePdfDto>> GenerateInvoiceAsync(Guid orderId, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
        {
            return JsonModel<InvoicePdfDto>.Error("Order not found.", 404);
        }

        // Validate Vendor GSTIN
        if (string.IsNullOrWhiteSpace(order.SellerGstin) || 
            order.SellerGstin.Contains("PENDING") || 
            order.SellerGstin.Contains("GSTIN_") || 
            order.SellerGstin.Length != 15)
        {
            return JsonModel<InvoicePdfDto>.Error("Invoice generation blocked. Vendor GSTIN is in a pending or invalid state.", 503);
        }

        // Generate QuestPDF Document
        byte[] pdfBytes;
        try
        {
            pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9));

                    // Header Block
                    page.Header().Column(column =>
                    {
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(titleCol =>
                            {
                                titleCol.Item().Text("TAX INVOICE").FontSize(16).Bold().FontColor("#0F172A");
                                titleCol.Item().Text("(Issued under Section 31 of GST Act, 2017)").FontSize(8).Italic().FontColor(Colors.Grey.Medium);
                            });
                        });
                        column.Item().PaddingTop(10).LineHorizontal(1).LineColor("#E2E8F0");
                    });

                    // Main Content Block
                    page.Content().PaddingTop(15).Column(column =>
                    {
                        // Info Grid (Seller / Metadata)
                        column.Item().Row(row =>
                        {
                            // Seller details
                            row.RelativeItem().Column(sellerCol =>
                            {
                                sellerCol.Item().Text("SELLER DETAILS").Bold().FontSize(9).FontColor("#0F172A");
                                sellerCol.Item().Text(order.SellerCompanyName).Bold();
                                sellerCol.Item().Text(order.SellerAddress);
                                sellerCol.Item().Text($"GSTIN: {order.SellerGstin}").Bold();
                                sellerCol.Item().Text($"State: {order.SellerStateName} ({order.SellerGstStateCode})");
                            });

                            // Invoice Metadata
                            row.RelativeItem().Column(metaCol =>
                            {
                                metaCol.Item().Text("INVOICE METADATA").Bold().FontSize(9).FontColor("#0F172A");
                                metaCol.Item().Text($"Invoice No: {order.InvoiceNumber}").Bold();
                                metaCol.Item().Text($"Date: {order.CreatedAt.ToString("dd-MMM-yyyy")}");
                                metaCol.Item().Text($"Place of Supply: {order.PlaceOfSupply} ({order.PlaceOfSupplyCode})");
                                metaCol.Item().Text($"Supply Type: {order.SupplyType}");
                            });
                        });

                        column.Item().PaddingTop(15).LineHorizontal(1).LineColor("#E2E8F0");

                        // Recipient Customer details
                        column.Item().PaddingTop(10).Column(buyerCol =>
                        {
                            buyerCol.Item().Text("BUYER (RECIPIENT) DETAILS").Bold().FontSize(9).FontColor("#0F172A");
                            buyerCol.Item().Text(order.CustomerName).Bold();
                            buyerCol.Item().Text($"{order.AddressLine1} {order.AddressLine2}, {order.City} - {order.Pincode}");
                            buyerCol.Item().Text($"Mobile: {order.Mobile} | Email: {order.Email}");
                            buyerCol.Item().Text($"Grade/Class: {order.GradeName}");
                            if (!string.IsNullOrWhiteSpace(order.CustomerGstin))
                            {
                                buyerCol.Item().Text($"Customer GSTIN: {order.CustomerGstin}");
                            }
                        });

                        column.Item().PaddingTop(15);

                        // Line Items Grid Table
                        column.Item().Table(table =>
                        {
                            // Define columns layout
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(25); // S.No
                                columns.RelativeColumn(3);  // Description
                                columns.ConstantColumn(40); // HSN
                                columns.ConstantColumn(25); // Qty
                                columns.ConstantColumn(50); // Rate
                                columns.ConstantColumn(60); // Taxable Value
                                columns.RelativeColumn(2);  // GST split
                                columns.ConstantColumn(60); // Total
                            });

                            // Table Headers row
                            table.Header(header =>
                            {
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("#").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).Text("Item Description").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("HSN").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("Qty").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignRight().Text("Rate (₹)").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignRight().Text("Taxable (₹)").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("GST Splits").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignRight().Text("Total (₹)").Bold().FontColor(Colors.White);
                            });

                            // Add order items details rows
                            int index = 1;
                            foreach (var item in order.Items)
                            {
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(index.ToString());
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).Text(item.ItemName);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(item.HsnCode);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(item.Quantity.ToString());
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(item.UnitPrice.ToString("0.00"));
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(item.BaseAmount.ToString("0.00"));

                                // GST Details Format column split
                                string gstText = "";
                                if (item.SupplyType == SupplyType.IntraState)
                                {
                                    gstText = $"CGST: {item.CgstPercent}%\n({item.CgstAmount:0.00})\nSGST: {item.SgstPercent}%\n({item.SgstAmount:0.00})";
                                }
                                else
                                {
                                    gstText = $"IGST: {item.IgstPercent}%\n({item.IgstAmount:0.00})";
                                }
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(gstText).FontSize(7);

                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(item.LineTotal.ToString("0.00"));
                                index++;
                            }

                            // Flat Delivery Fee row if charged
                            if (order.DeliveryFee > 0)
                            {
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(index.ToString());
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).Text("Delivery / Shipping Charges");
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("9965");
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("1");
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(order.DeliveryFee.ToString("0.00"));
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(order.DeliveryFee.ToString("0.00"));

                                string delGstText = "";
                                if (order.SupplyType == SupplyType.IntraState)
                                {
                                    delGstText = $"CGST: 9%\n({order.DeliveryCgstAmount:0.00})\nSGST: 9%\n({order.DeliverySgstAmount:0.00})";
                                }
                                else
                                {
                                    delGstText = $"IGST: 18%\n({order.DeliveryIgstAmount:0.00})";
                                }
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(delGstText).FontSize(7);

                                decimal delTotal = order.DeliveryFee + order.DeliveryGst;
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(delTotal.ToString("0.00"));
                            }
                        });

                        column.Item().PaddingTop(15);

                        // Totals summary pricing card
                        column.Item().AlignRight().Width(220).Border(1).BorderColor("#E2E8F0").Padding(8).Column(totalsCol =>
                        {
                            totalsCol.Item().Row(r =>
                            {
                                r.RelativeItem().Text("Taxable Subtotal:");
                                r.ConstantItem(80).AlignRight().Text(order.SubTotal.ToString("C", new System.Globalization.CultureInfo("en-IN")));
                            });

                            if (order.SupplyType == SupplyType.IntraState)
                            {
                                decimal cgstTotal = order.Items.Sum(i => i.CgstAmount) + order.DeliveryCgstAmount;
                                decimal sgstTotal = order.Items.Sum(i => i.SgstAmount) + order.DeliverySgstAmount;

                                totalsCol.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("CGST:");
                                    r.ConstantItem(80).AlignRight().Text(cgstTotal.ToString("C", new System.Globalization.CultureInfo("en-IN")));
                                });
                                totalsCol.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("SGST:");
                                    r.ConstantItem(80).AlignRight().Text(sgstTotal.ToString("C", new System.Globalization.CultureInfo("en-IN")));
                                });
                            }
                            else
                            {
                                decimal igstTotal = order.Items.Sum(i => i.IgstAmount) + order.DeliveryIgstAmount;

                                totalsCol.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("IGST:");
                                    r.ConstantItem(80).AlignRight().Text(igstTotal.ToString("C", new System.Globalization.CultureInfo("en-IN")));
                                });
                            }

                            totalsCol.Item().PaddingVertical(4).LineHorizontal(1).LineColor("#E2E8F0");

                            totalsCol.Item().Row(r =>
                            {
                                r.RelativeItem().Text("Grand Total:").Bold();
                                r.ConstantItem(80).AlignRight().Text(order.GrandTotal.ToString("C", new System.Globalization.CultureInfo("en-IN"))).Bold();
                            });
                        });

                        // Legal declaration signoff
                        column.Item().PaddingTop(25).Column(decCol =>
                        {
                            decCol.Item().Text("DECLARATION & SIGNATURE").Bold().FontSize(8);
                            decCol.Item().Text("\"We declare that this invoice shows the actual price of the goods described and that all particulars are true and correct.\"").FontSize(8).Italic().FontColor(Colors.Grey.Medium);
                            decCol.Item().PaddingTop(15).AlignRight().Text($"For {order.SellerCompanyName}").Bold();
                            decCol.Item().PaddingTop(10).AlignRight().Text("Authorized Signatory").Italic();
                        });
                    });

                    // Footer Page details
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" of ");
                        x.TotalPages();
                    });
                });
            }).GeneratePdf();
        }
        catch (Exception ex)
        {
            return JsonModel<InvoicePdfDto>.Error($"Error rendering PDF document: {ex.Message}", 500);
        }

        var dto = new InvoicePdfDto(order.InvoiceNumber, pdfBytes, "application/pdf");
        return JsonModel<InvoicePdfDto>.Success(dto, "Invoice PDF generated successfully.");
    }
}
