using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.Dal.Inventory.Existence;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// Existence endpoints
/// </summary>
[ApiController()]
[Route("api/inventory/existence")]
public class ExistenceController : ControllerBase
{
    private readonly IGetExistenceService _getExistenceService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="getExistenceService"></param>
    public ExistenceController(
        IGetExistenceService getExistenceService)
    {
        _getExistenceService = getExistenceService;
    }

    /// <summary>
    /// Get existence
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getExistenceService.GetExistenceAsync();
        return Ok(result);
    }
}