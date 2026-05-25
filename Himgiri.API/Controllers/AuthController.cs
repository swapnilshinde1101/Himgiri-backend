using Himgiri.Core.DTOs;
using Himgiri.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Route("api/auth")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        try 
        {
            var result = await _authService.LoginAsync(request, ct);

            if (result is null)
                return ErrorResponse("Invalid email or password.", 401);

            return OkResponse(result, "Login successful.");
        }
        catch (UnauthorizedAccessException ex)
        {
            return ErrorResponse(ex.Message, 401);
        }
    }

    /// <summary>
    /// Checks if the current token is valid and the server is alive.
    /// </summary>
    [HttpGet("validate")]
    [Authorize]
    public IActionResult ValidateToken()
    {
        return OkResponse(new { valid = true, time = DateTime.UtcNow }, "Session is active.");
    }
}
