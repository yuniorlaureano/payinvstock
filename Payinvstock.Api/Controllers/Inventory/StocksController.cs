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
    public StocksController(
        ICreateStockService createStockService)
    {
        _createStockService = createStockService;
    }

    ///// <summary>
    ///// Get stock
    ///// </summary>
    ///// <returns></returns>
    //[HttpGet()]
    //public async Task<IActionResult> Get()
    //{
    //    var result = await _getStockReasonService.GetStockReasonsAsync();
    //    return Ok(result);
    //}

    /// <summary>
    /// Get Stock by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[HttpGet("{id}")]
    //public async Task<IActionResult> Get(Guid id)
    //{
    //    var result = await _getStockReasonService.GetStockReasonAsync(id);
    //    return Ok(result);
    //}

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
    //[HttpPut("{id}")]
    //public async Task<IActionResult> Put(Guid id, UpdateStockReasonDto model)
    //{
    //    await _updateStockReasonService.UpdateStockReasonAsync(id, model);
    //    return NoContent();
    //}

    /// <summary>
    /// Delete a Stock
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    await _deleteStockReasonService.DeleteStockReasonAsync(id);
    //    return NoContent();
    //}
}