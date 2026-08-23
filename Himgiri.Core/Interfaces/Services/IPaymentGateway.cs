using Himgiri.Core.Entities;
using Himgiri.Core.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Himgiri.Core.Interfaces.Services;

public interface IPaymentGateway
{
    Task<InitiatePaymentResponse> CreatePaymentAsync(
        Order order,
        string callbackUrl,
        CancellationToken ct = default);

    Task<bool> VerifyWebhookSignatureAsync(
        string rawBody,
        string receivedSignature);
}
