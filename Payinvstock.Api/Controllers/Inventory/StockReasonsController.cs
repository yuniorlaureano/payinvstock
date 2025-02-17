using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.Inventory.StockReason;
using Payinvstock.Dto.Inventory.StockReason;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// StockReasons endpoints
/// </summary>
[ApiController()]
[Route("api/inventory/stock/reasons")]
public class StockReasonsController : ControllerBase
{
    private readonly IGetStockReasonService _getStockReasonService;
    private readonly ICreateStockReasonService _createStockReasonService;
    private readonly IUpdateStockReasonService _updateStockReasonService;
    private readonly IDeleteStockReasonService _deleteStockReasonService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="getStockReasonService"></param>
    /// <param name="createStockReasonService"></param>
    /// <param name="updateStockReasonService"></param>
    /// <param name="deleteStockReasonService"></param>
    public StockReasonsController(
        IGetStockReasonService getStockReasonService,
        ICreateStockReasonService createStockReasonService,
        IUpdateStockReasonService updateStockReasonService,
        IDeleteStockReasonService deleteStockReasonService)
    {
        _getStockReasonService = getStockReasonService;
        _createStockReasonService = createStockReasonService;
        _updateStockReasonService = updateStockReasonService;
        _deleteStockReasonService = deleteStockReasonService;
    }

    /// <summary>
    /// Get stock reasons
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getStockReasonService.GetStockReasonsAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get StockReason by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getStockReasonService.GetStockReasonAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new StockReason
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateStockReasonDto model)
    {
        await _createStockReasonService.CreateStockReasonAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a StockReason
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateStockReasonDto model)
    {
        await _updateStockReasonService.UpdateStockReasonAsync(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete a StockReason
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteStockReasonService.DeleteStockReasonAsync(id);
        return NoContent();
    }
}