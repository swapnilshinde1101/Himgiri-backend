using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.API.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace Himgiri.API.Middleware;

public partial class ApiAuditLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _scopeFactory;

    public ApiAuditLoggingMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
    {
        _next = next;
        _scopeFactory = scopeFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 1. Buffer the request
        context.Request.EnableBuffering();
        var requestBody = await ReadRequestBody(context.Request);

        // 2. Capture the original response stream
        var originalResponseBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            // 3. Log if it's an error (400+)
            if (context.Response.StatusCode >= 400)
            {
                var responseText = await ReadResponseBody(context.Response);
                await SaveLogInIsolatedScope(context, requestBody, responseText);
            }
        }
        catch (Exception ex)
        {
            // 4. Log unhandled exceptions
            await SaveLogInIsolatedScope(context, requestBody, null, ex);
            throw; // Re-throw for ExceptionMiddleware to handle
        }
        finally
        {
            // 5. Copy the captured response back to the original stream
            responseBody.Position = 0;
            await responseBody.CopyToAsync(originalResponseBodyStream);
            context.Response.Body = originalResponseBodyStream;
        }
    }

    private async Task SaveLogInIsolatedScope(HttpContext context, string requestBody, string? responseText, Exception? ex = null)
    {
        try
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
                return;

            using var scope = _scopeFactory.CreateScope();
            var logRepo = scope.ServiceProvider.GetRequiredService<IApiErrorLogRepository>();

            var log = new ApiErrorLog
            {
                RequestType = context.Request.Method,
                Url = context.Request.Path + context.Request.QueryString,
                QueryParams = context.Request.QueryString.ToString(),
                IpAddress = context.Connection.RemoteIpAddress?.ToString(),
                UserAgent = context.Request.Headers["User-Agent"].FirstOrDefault(),
                ResponseCode = context.Response.StatusCode,
                Payload = MaskSensitiveData(requestBody),
                Response = responseText,
                
                UserId = context.User.GetUserId() != Guid.Empty ? context.User.GetUserId() : null,
                UserEmail = context.User.GetUserEmail(),
                
                ExceptionMessage = ex?.Message,
                StackTrace = ex?.StackTrace
            };

            await logRepo.AddAsync(log);
        }
        catch
        {
            // Suppress logging write errors to ensure client response pipeline is never broken
        }
    }

    private string MaskSensitiveData(string content)
    {
        if (string.IsNullOrWhiteSpace(content)) return content;
        
        // Mask passwords in JSON
        var masked = PasswordRegex().Replace(content, "\"password\":\"********\"");
        return masked;
    }

    [GeneratedRegex(@"""password""\s*:\s*""(?:[^""\\]|\\.)*""", RegexOptions.IgnoreCase)]
    private static partial Regex PasswordRegex();

    private async Task<string> ReadRequestBody(HttpRequest request)
    {
        request.Body.Position = 0;
        using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;
        return body;
    }

    private async Task<string> ReadResponseBody(HttpResponse response)
    {
        response.Body.Position = 0;
        using var reader = new StreamReader(response.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        response.Body.Position = 0;
        return body;
    }
}
