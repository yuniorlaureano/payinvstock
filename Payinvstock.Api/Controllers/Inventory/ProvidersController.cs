using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.Inventory.Provider;
using Payinvstock.Dto.Inventory.Provider;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// Providers endpoints
/// </summary>
[ApiController()]
[Route("api/inventory/providers")]
public class ProvidersController : ControllerBase
{
    private readonly IGetProviderService _getProviderService;
    private readonly ICreateProviderService _createProviderService;
    private readonly IUpdateProviderService _updateProviderService;
    private readonly IDeleteProviderService _deleteProviderService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="getProviderService"></param>
    /// <param name="createProviderService"></param>
    /// <param name="updateProviderService"></param>
    /// <param name="deleteProviderService"></param>
    public ProvidersController(
        IGetProviderService getProviderService,
        ICreateProviderService createProviderService,
        IUpdateProviderService updateProviderService,
        IDeleteProviderService deleteProviderService)
    {
        _getProviderService = getProviderService;
        _createProviderService = createProviderService;
        _updateProviderService = updateProviderService;
        _deleteProviderService = deleteProviderService;
    }

    /// <summary>
    /// Get providers
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getProviderService.GetProvidersAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get provider by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getProviderService.GetProviderAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new provider
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateProviderDto model)
    {
        await _createProviderService.CreateProviderAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a provider
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateProviderDto model)
    {
        await _updateProviderService.UpdateProviderAsync(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete a provider
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteProviderService.DeleteProviderAsync(id);
        return NoContent();
    }
}