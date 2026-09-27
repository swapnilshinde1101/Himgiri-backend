using System.Threading;
using System.Threading.Tasks;

namespace Himgiri.Core.Interfaces.Services;

public interface IWhatsAppService
{
    Task<bool> SendWhatsAppMessageAsync(
        string mobileNumber, 
        string messageText, 
        CancellationToken ct = default);
}
