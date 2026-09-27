using System;
using System.Net;

namespace Himgiri.Core.Exceptions;

/// <summary>
/// Base application exception with HTTP status code mapping.
/// </summary>
public abstract class AppException : Exception
{
    public int StatusCode { get; }

    protected AppException(string message, int statusCode = (int)HttpStatusCode.InternalServerError)
        : base(message)
    {
        StatusCode = statusCode;
    }

    protected AppException(string message, Exception innerException, int statusCode = (int)HttpStatusCode.InternalServerError)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}

public class NotFoundException : AppException
{
    public NotFoundException(string message)
        : base(message, (int)HttpStatusCode.NotFound)
    {
    }

    public NotFoundException(string entityName, object key)
        : base($"{entityName} with id '{key}' was not found.", (int)HttpStatusCode.NotFound)
    {
    }
}

public class ValidationException : AppException
{
    public ValidationException(string message)
        : base(message, (int)HttpStatusCode.BadRequest)
    {
    }
}

public class ConflictException : AppException
{
    public ConflictException(string message)
        : base(message, (int)HttpStatusCode.Conflict)
    {
    }
}

public class UnauthorizedException : AppException
{
    public UnauthorizedException(string message = "Unauthorized access.")
        : base(message, (int)HttpStatusCode.Unauthorized)
    {
    }
}

public class ForbiddenException : AppException
{
    public ForbiddenException(string message = "You do not have permission to access this resource.")
        : base(message, (int)HttpStatusCode.Forbidden)
    {
    }
}
