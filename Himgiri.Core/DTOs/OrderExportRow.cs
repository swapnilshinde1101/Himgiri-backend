using System.ComponentModel;

namespace Himgiri.Core.DTOs;

public class OrderExportRow
{
    [DisplayName("Invoice Number")]
    public string InvoiceNumber { get; set; } = string.Empty;

    [DisplayName("Customer Name")]
    public string CustomerName { get; set; } = string.Empty;

    [DisplayName("Mobile")]
    public string Mobile { get; set; } = string.Empty;

    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Grade Name")]
    public string Grade { get; set; } = string.Empty;

    [DisplayName("Grand Total (INR)")]
    public decimal GrandTotal { get; set; }

    [DisplayName("Order Status")]
    public string Status { get; set; } = string.Empty;

    [DisplayName("Created At")]
    public string CreatedAt { get; set; } = string.Empty;

    [DisplayName("Delivery Address")]
    public string Address { get; set; } = string.Empty;
}
