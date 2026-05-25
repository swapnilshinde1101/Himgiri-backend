using Himgiri.Core.DTOs;

namespace Himgiri.Core.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default);
    string GenerateToken(Core.Entities.AdminUser user);
}
