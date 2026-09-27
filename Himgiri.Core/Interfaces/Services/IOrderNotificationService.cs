using System;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IOrderNotificationService
{
    Task<JsonModel<bool>> SendOrderConfirmationAsync(Guid orderId, CancellationToken ct = default);
    Task<JsonModel<bool>> SendOrderDispatchedAsync(Guid orderId, CancellationToken ct = default);
    Task<JsonModel<bool>> SendOrderCancelledAsync(Guid orderId, string reason, CancellationToken ct = default);
}
