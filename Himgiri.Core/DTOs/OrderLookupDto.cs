using System;
using System.Collections.Generic;

namespace Himgiri.Core.DTOs
{
    public class OrderLookupDto
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public decimal GrandTotal { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public bool IsHomeDelivery { get; set; }
        public List<OrderLookupItemDto> Items { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}
