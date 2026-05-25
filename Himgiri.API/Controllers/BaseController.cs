using Himgiri.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult OkResponse<T>(T data, string message = "Success")
    {
        return Ok(JsonModel<T>.Success(data, message));
    }

    protected IActionResult CreatedResponse<T>(T data, string message = "Resource created successfully")
    {
        return StatusCode(201, JsonModel<T>.Success(data, message));
    }

    protected IActionResult ErrorResponse(string message, int statusCode = 400, string appError = "")
    {
        return StatusCode(statusCode, JsonModel<object>.Error(message, statusCode, appError));
    }

    protected IActionResult PagedResponse<T>(List<T> data, int totalRecords, int pageNumber, int pageSize, string message = "Success")
    {
        var meta = new Meta(totalRecords, pageNumber, pageSize);
        var response = new JsonModel<List<T>>(data, message, 200, "", meta);
        return Ok(response);
    }
}
