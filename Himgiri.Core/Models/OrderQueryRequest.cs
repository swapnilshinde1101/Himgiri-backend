using Himgiri.Core.Enums;

namespace Himgiri.Core.Models;

public class OrderQueryRequest : BaseRequest
{
    public OrderStatus? Status { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
}
