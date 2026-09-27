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

        // Validate Vendor GSTIN (with auto-recovery from active VendorSettings if snapshot was pending)
        if (string.IsNullOrWhiteSpace(order.SellerGstin) || 
            order.SellerGstin.Contains("PENDING") || 
            order.SellerGstin.Contains("GSTIN_") || 
            order.SellerGstin.Length != 15)
        {
            var vendorSettings = await _db.VendorSettings.FirstOrDefaultAsync(ct);
            if (vendorSettings != null && 
                !string.IsNullOrWhiteSpace(vendorSettings.Gstin) && 
                !vendorSettings.Gstin.Contains("PENDING") && 
                !vendorSettings.Gstin.Contains("GSTIN_") && 
                vendorSettings.Gstin.Length == 15)
            {
                order.SellerGstin = vendorSettings.Gstin;
                if (string.IsNullOrWhiteSpace(order.SellerCompanyName) && !string.IsNullOrWhiteSpace(vendorSettings.CompanyName))
                {
                    order.SellerCompanyName = vendorSettings.CompanyName;
                }
                if (string.IsNullOrWhiteSpace(order.SellerAddress) && !string.IsNullOrWhiteSpace(vendorSettings.Address))
                {
                    order.SellerAddress = vendorSettings.Address;
                }
                await _db.SaveChangesAsync(ct);
            }
            else
            {
                return JsonModel<InvoicePdfDto>.Error("Invoice generation blocked. Vendor GSTIN is in a pending or invalid state.", 503);
            }
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

    public async Task<JsonModel<DeliveryChallanPdfDto>> GenerateDeliveryChallanAsync(Guid orderId, CancellationToken ct = default)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted, ct);

        if (order == null)
        {
            return JsonModel<DeliveryChallanPdfDto>.Error("Order not found.", 404);
        }

        string challanNumber = !string.IsNullOrWhiteSpace(order.InvoiceNumber)
            ? $"DC-{order.InvoiceNumber}"
            : $"DC-{order.Id.ToString()[..8].ToUpper()}";

        // Auto-recover valid SellerGstin if snapshot was pending
        if (string.IsNullOrWhiteSpace(order.SellerGstin) || 
            order.SellerGstin.Contains("PENDING") || 
            order.SellerGstin.Contains("GSTIN_") || 
            order.SellerGstin.Length != 15)
        {
            var vendorSettings = await _db.VendorSettings.FirstOrDefaultAsync(ct);
            if (vendorSettings != null && 
                !string.IsNullOrWhiteSpace(vendorSettings.Gstin) && 
                !vendorSettings.Gstin.Contains("PENDING") && 
                !vendorSettings.Gstin.Contains("GSTIN_") && 
                vendorSettings.Gstin.Length == 15)
            {
                order.SellerGstin = vendorSettings.Gstin;
                if (string.IsNullOrWhiteSpace(order.SellerCompanyName) && !string.IsNullOrWhiteSpace(vendorSettings.CompanyName))
                {
                    order.SellerCompanyName = vendorSettings.CompanyName;
                }
                if (string.IsNullOrWhiteSpace(order.SellerAddress) && !string.IsNullOrWhiteSpace(vendorSettings.Address))
                {
                    order.SellerAddress = vendorSettings.Address;
                }
                await _db.SaveChangesAsync(ct);
            }
        }

        // Generate QuestPDF Document for Delivery Challan (Rule 55 CGST)
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
                                titleCol.Item().Text("DELIVERY CHALLAN").FontSize(16).Bold().FontColor("#0F172A");
                                titleCol.Item().Text("(Issued in accordance with Rule 55 of CGST Rules, 2017)").FontSize(8).Italic().FontColor(Colors.Grey.Medium);
                                titleCol.Item().Text("GOODS DISPATCH MANIFEST & WAREHOUSE PACKING SLIP").FontSize(8.5f).Bold().FontColor("#0284C7");
                            });

                            row.RelativeItem().AlignRight().Column(metaCol =>
                            {
                                metaCol.Item().Text($"Challan No: {challanNumber}").Bold().FontSize(11).FontColor("#0F172A");
                                metaCol.Item().Text($"Invoice Ref: {order.InvoiceNumber}").FontSize(8.5f);
                                metaCol.Item().Text($"Date: {order.CreatedAt:dd-MMM-yyyy}").FontSize(8.5f);
                                metaCol.Item().PaddingTop(3).Text(order.IsHomeDelivery ? "[ HOME DELIVERY / COURIER ]" : "[ CAMPUS HANDOVER / CLASSROOM ]")
                                    .Bold().FontSize(8.5f).FontColor(order.IsHomeDelivery ? "#C2410C" : "#0F766E");
                            });
                        });
                        column.Item().PaddingTop(8).LineHorizontal(1).LineColor("#E2E8F0");
                    });

                    // Main Content Block
                    page.Content().PaddingTop(12).Column(column =>
                    {
                        // Info Grid (Consignor / Consignee)
                        column.Item().Row(row =>
                        {
                            // Consignor (Seller) details
                            row.RelativeItem().Column(sellerCol =>
                            {
                                sellerCol.Item().Text("CONSIGNOR (SUPPLIER / WAREHOUSE)").Bold().FontSize(8.5f).FontColor("#475569");
                                sellerCol.Item().Text(order.SellerCompanyName).Bold();
                                sellerCol.Item().Text(order.SellerAddress);
                                sellerCol.Item().Text($"GSTIN: {order.SellerGstin ?? "N/A"}").Bold();
                                sellerCol.Item().Text($"State: {order.SellerStateName} ({order.SellerGstStateCode})");
                            });

                            // Consignee (Buyer / Student) details
                            row.RelativeItem().Column(buyerCol =>
                            {
                                buyerCol.Item().Text("CONSIGNEE (RECIPIENT & DESTINATION)").Bold().FontSize(8.5f).FontColor("#475569");
                                buyerCol.Item().Text(order.CustomerName).Bold();
                                buyerCol.Item().Text($"Grade / Class: {order.GradeName}").Bold().FontColor("#0F766E");
                                buyerCol.Item().Text($"Mobile: {order.Mobile} | Email: {order.Email}");
                                if (order.IsHomeDelivery)
                                {
                                    buyerCol.Item().Text($"Address: {order.AddressLine1} {order.AddressLine2}, {order.City} - {order.Pincode}");
                                }
                                else
                                {
                                    buyerCol.Item().Text($"Destination: School Campus Handover ({order.City} - {order.Pincode})");
                                }
                                buyerCol.Item().Text($"Place of Supply: {order.PlaceOfSupply} ({order.PlaceOfSupplyCode})");
                            });
                        });

                        column.Item().PaddingTop(12).LineHorizontal(1).LineColor("#E2E8F0");

                        // Line Items Grid Table
                        column.Item().PaddingTop(10).Table(table =>
                        {
                            // Define columns layout
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40); // Checkbox [ ]
                                columns.ConstantColumn(25); // S.No
                                columns.RelativeColumn(3);  // Description
                                columns.ConstantColumn(45); // HSN
                                columns.ConstantColumn(55); // Category / Type
                                columns.ConstantColumn(35); // Qty
                                columns.ConstantColumn(50); // Rate
                                columns.ConstantColumn(60); // Taxable Value
                                columns.ConstantColumn(60); // Total
                            });

                            // Table Headers row
                            table.Header(header =>
                            {
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("Packed").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("#").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).Text("Item Description").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("HSN").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("Type").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignCenter().Text("Qty").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignRight().Text("Rate (₹)").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignRight().Text("Taxable (₹)").Bold().FontColor(Colors.White);
                                header.Cell().Background("#0F172A").Padding(4).AlignRight().Text("Total (₹)").Bold().FontColor(Colors.White);
                            });

                            int index = 1;
                            foreach (var item in order.Items)
                            {
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("[  ]").FontColor(Colors.Grey.Medium);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(index.ToString());
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).Text(item.ItemName).Bold();
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(item.HsnCode);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(item.IsKitItem ? "Kit Item" : "Individual").FontSize(7.5f);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(item.Quantity.ToString()).Bold();
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(item.UnitPrice.ToString("0.00"));
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(item.BaseAmount.ToString("0.00"));
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(item.LineTotal.ToString("0.00"));
                                index++;
                            }

                            if (order.DeliveryFee > 0)
                            {
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("[  ]").FontColor(Colors.Grey.Medium);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text(index.ToString());
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).Text("Delivery / Shipping Charges").Bold();
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("9965");
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("Service").FontSize(7.5f);
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignCenter().Text("1").Bold();
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(order.DeliveryFee.ToString("0.00"));
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(order.DeliveryFee.ToString("0.00"));
                                decimal delTotal = order.DeliveryFee + order.DeliveryGst;
                                table.Cell().BorderBottom(1).BorderColor("#F1F5F9").Padding(4).AlignRight().Text(delTotal.ToString("0.00"));
                            }
                        });

                        column.Item().PaddingTop(12);

                        // Totals & Dispatch Summary Card
                        column.Item().AlignRight().Width(240).Border(1).BorderColor("#E2E8F0").Padding(8).Column(totalsCol =>
                        {
                            int totalUnits = order.Items.Sum(i => i.Quantity);
                            totalsCol.Item().Row(r =>
                            {
                                r.RelativeItem().Text("Total Units Dispatched:").Bold();
                                r.ConstantItem(80).AlignRight().Text($"{totalUnits} pcs").Bold();
                            });
                            totalsCol.Item().Row(r =>
                            {
                                r.RelativeItem().Text("Total Packages:");
                                r.ConstantItem(80).AlignRight().Text("1 Parcel");
                            });
                            totalsCol.Item().Row(r =>
                            {
                                r.RelativeItem().Text("Consignment Value:").Bold();
                                r.ConstantItem(80).AlignRight().Text(order.GrandTotal.ToString("C", new System.Globalization.CultureInfo("en-IN"))).Bold();
                            });
                            totalsCol.Item().Row(r =>
                            {
                                r.RelativeItem().Text("Payment Status:");
                                r.ConstantItem(80).AlignRight().Text(order.PaymentStatus.ToString()).Bold();
                            });
                        });

                        // Verification and Handover Signatures (3 columns)
                        column.Item().PaddingTop(25).Row(sigRow =>
                        {
                            sigRow.RelativeItem().Border(1).BorderColor("#E2E8F0").Padding(8).Column(c =>
                            {
                                c.Item().Text("1. WAREHOUSE PICK & PACK").Bold().FontSize(8).FontColor("#475569");
                                c.Item().PaddingTop(25).LineHorizontal(1).LineColor("#CBD5E1");
                                c.Item().PaddingTop(2).AlignCenter().Text("Picked & Packed By (Sign & Date)").FontSize(7.5f);
                            });

                            sigRow.ConstantItem(10);

                            sigRow.RelativeItem().Border(1).BorderColor("#E2E8F0").Padding(8).Column(c =>
                            {
                                c.Item().Text("2. DISPATCH & LOGISTICS").Bold().FontSize(8).FontColor("#475569");
                                c.Item().PaddingTop(25).LineHorizontal(1).LineColor("#CBD5E1");
                                c.Item().PaddingTop(2).AlignCenter().Text("Handed to Courier / Van (Sign & Date)").FontSize(7.5f);
                            });

                            sigRow.ConstantItem(10);

                            sigRow.RelativeItem().Border(1).BorderColor("#E2E8F0").Padding(8).Column(c =>
                            {
                                c.Item().Text("3. RECEIVER ACKNOWLEDGMENT").Bold().FontSize(8).FontColor("#475569");
                                c.Item().PaddingTop(25).LineHorizontal(1).LineColor("#CBD5E1");
                                c.Item().PaddingTop(2).AlignCenter().Text("Received in Good Condition (Sign & Date)").FontSize(7.5f);
                            });
                        });

                        // Legal declaration signoff (Rule 55)
                        column.Item().PaddingTop(15).Column(decCol =>
                        {
                            decCol.Item().Text("STATUTORY DECLARATION (RULE 55, CGST RULES 2017)").Bold().FontSize(8);
                            decCol.Item().Text("\"Certified that the particulars given above are true and correct. The goods described above are dispatched under Delivery Challan as per Rule 55 of CGST Rules, 2017 for supply/delivery to the consignee. Not for resale.\"").FontSize(7.5f).Italic().FontColor(Colors.Grey.Medium);
                        });
                    });

                    // Footer Page details
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" of ");
                        x.TotalPages();
                        x.Span(" | Himgiri Warehouse Dispatch & Logistics Manifest");
                    });
                });
            }).GeneratePdf();
        }
        catch (Exception ex)
        {
            return JsonModel<DeliveryChallanPdfDto>.Error($"Error rendering Delivery Challan PDF: {ex.Message}", 500);
        }

        var dto = new DeliveryChallanPdfDto(challanNumber, pdfBytes, "application/pdf");
        return JsonModel<DeliveryChallanPdfDto>.Success(dto, "Delivery Challan PDF generated successfully.");
    }
}
