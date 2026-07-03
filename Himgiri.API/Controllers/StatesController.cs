using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Himgiri.API.Controllers;

[Route("api/states")]
public class StatesController : BaseController
{
    private readonly IStateService _stateService;

    public StatesController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStates(CancellationToken ct)
    {
        var result = await _stateService.GetAllActiveAsync(ct);
        if (result.StatusCode != 200)
        {
            return ErrorResponse(result.Message, result.StatusCode);
        }
        return OkResponse(result.Data, result.Message);
    }
}
