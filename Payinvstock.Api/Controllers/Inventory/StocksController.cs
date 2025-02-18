using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.Inventory.Stock;
using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// Stocks endpoints
/// </summary>
[ApiController()]
[Route("api/inventory/stocks")]
public class StocksController : ControllerBase
{
    private readonly ICreateStockService _createStockService;
    private readonly IGetStockService _getStockService;
    private readonly IUpdateStockService _updateStockService;
    private readonly ICancelStockService _cancelStockService;

    public StocksController(
        ICreateStockService createStockService,
        IGetStockService getStockService,
        IUpdateStockService updateStockService,
        ICancelStockService cancelStockService)
    {
        _createStockService = createStockService;
        _getStockService = getStockService;
        _updateStockService = updateStockService;
        _cancelStockService = cancelStockService;
    }

    /// <summary>
    /// Get stock
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getStockService.GetStocksAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get stock by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getStockService.GetStockAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new Stock
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateStockDto model)
    {
        await _createStockService.CreateStockAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a Stock
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateStockDto model)
    {
        await _updateStockService.UpdateStockAsync(id, model);
        return NoContent();
    }

    /// <summary>
    /// Cancel a Stock
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _cancelStockService.CancelStockAsync(id);
        return NoContent();
    }
}