namespace Himgiri.Core.Models;

public class JsonModel
{
    public JsonModel(object? data, string message, int statusCode, string appError = "", Meta? meta = null)
    {
        Data = data;
        Message = message;
        StatusCode = statusCode;
        AppError = appError;
        Meta = meta;
    }

    public object? Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public string AppError { get; set; }
    public Meta? Meta { get; set; }
}

public class JsonModel<T>
{
    public JsonModel(T? data, string message, int statusCode, string appError = "", Meta? meta = null)
    {
        Data = data;
        Message = message;
        StatusCode = statusCode;
        AppError = appError;
        Meta = meta;
    }

    public T? Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public string AppError { get; set; }
    public Meta? Meta { get; set; }

    public static JsonModel<T> Success(T data, string message = "Success")
    {
        return new JsonModel<T>(data, message, 200);
    }

    public static JsonModel<T> Error(string message, int statusCode = 400, string appError = "")
    {
        return new JsonModel<T>(default, message, statusCode, appError);
    }
}

public class Meta
{
    public Meta() { }

    public Meta(int totalRecords, int pageNumber, int pageSize)
    {
        TotalRecords = totalRecords;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
    }

    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalRecords { get; set; }
}
