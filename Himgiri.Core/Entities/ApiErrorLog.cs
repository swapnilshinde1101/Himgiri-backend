namespace Himgiri.Core.Entities;

public class ApiErrorLog : BaseEntity
{
    public string RequestType { get; set; } = string.Empty; // GET, POST, etc.
    public string Url { get; set; } = string.Empty;
    public string? Payload { get; set; }      // Masked request body
    public string? QueryParams { get; set; }
    public string? Response { get; set; }     // Error message or response body
    public int ResponseCode { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    
    // Context
    public Guid? UserId { get; set; }
    public string? UserEmail { get; set; }
    public string? ExceptionMessage { get; set; }
    public string? StackTrace { get; set; }
}
