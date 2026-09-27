using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Himgiri.Core.Exceptions;
using Himgiri.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Himgiri.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException)
        {
            // Client closed tab / aborted HTTP request — log as info, do not fail
            _logger.LogInformation("HTTP request cancelled by client. Path: {Path}, TraceId: {TraceId}", 
                context.Request.Path, context.TraceIdentifier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Message}. Path: {Path}, TraceId: {TraceId}", 
                ex.Message, context.Request.Path, context.TraceIdentifier);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        if (context.Response.HasStarted)
        {
            _logger.LogWarning("Response has already started; cannot write error response for {Path}", context.Request.Path);
            return;
        }

        context.Response.ContentType = "application/json";

        int statusCode;
        string message;

        switch (exception)
        {
            case AppException appEx:
                statusCode = appEx.StatusCode;
                message = appEx.Message;
                break;

            case DbUpdateConcurrencyException:
                statusCode = (int)HttpStatusCode.Conflict;
                message = "The record was concurrently modified or deleted by another user. Please refresh and try again.";
                break;

            case BadHttpRequestException:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Invalid request payload or malformed JSON structure.";
                break;

            case UnauthorizedAccessException:
                statusCode = (int)HttpStatusCode.Unauthorized;
                message = "Unauthorized access.";
                break;

            case KeyNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                message = exception.Message;
                break;

            case InvalidOperationException:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = _env.IsDevelopment() 
                    ? exception.Message 
                    : "The requested operation is not valid in the current state.";
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                message = _env.IsDevelopment()
                    ? $"{exception.Message} ({exception.GetType().Name})"
                    : $"An unexpected server error occurred. Please contact support quoting Error ID: {context.TraceIdentifier}";
                break;
        }

        context.Response.StatusCode = statusCode;

        var response = JsonModel<object>.Error(message, statusCode, context.TraceIdentifier);

        var jsonOptions = new JsonSerializerOptions 
        { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false 
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
    }
}
