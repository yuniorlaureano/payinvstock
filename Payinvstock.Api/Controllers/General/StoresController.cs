using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.General.Store;
using Payinvstock.Dto.General.Store;

namespace Payinvstock.Api.Controllers.General;

/// <summary>
/// Stores endpoints
/// </summary>
[ApiController()]
[Route("api/general/stores")]
public class StoresController : ControllerBase
{
    private readonly IGetStoreService _getStoreService;
    private readonly ICreateStoreService _createStoreService;
    private readonly IUpdateStoreService _updateStoreService;
    private readonly IDeleteStoreService _deleteStoreService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="getStoreService"></param>
    /// <param name="createStoreService"></param>
    /// <param name="updateStoreService"></param>
    /// <param name="deleteStoreService"></param>
    public StoresController(
        IGetStoreService getStoreService,
        ICreateStoreService createStoreService,
        IUpdateStoreService updateStoreService,
        IDeleteStoreService deleteStoreService)
    {
        _getStoreService = getStoreService;
        _createStoreService = createStoreService;
        _updateStoreService = updateStoreService;
        _deleteStoreService = deleteStoreService;
    }

    /// <summary>
    /// Get Stores
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getStoreService.GetStoresAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get Store by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getStoreService.GetStoreAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new Store
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateStoreDto model)
    {
        await _createStoreService.CreateStoreAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a Store
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateStoreDto model)
    {
        await _updateStoreService.UpdateStoreAsync(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete a Store
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteStoreService.DeleteStoreAsync(id);
        return NoContent();
    }
}