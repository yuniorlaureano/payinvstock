using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Dto.General.Unit;

namespace Payinvstock.Api.Controllers.General;

/// <summary>
/// Units endpoints
/// </summary>
[ApiController()]
[Route("api/general/units")]
public class UnitsController : ControllerBase
{
    private readonly IGetUnitService _getUnitService;
    private readonly ICreateUnitService _createUnitService;
    private readonly IUpdateUnitService _updateUnitService;
    private readonly IDeleteUnitService _deleteUnitService;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="getUnitService"></param>
    /// <param name="createUnitService"></param>
    /// <param name="updateUnitService"></param>
    /// <param name="deleteUnitService"></param>
    public UnitsController(
        IGetUnitService getUnitService,
        ICreateUnitService createUnitService,
        IUpdateUnitService updateUnitService,
        IDeleteUnitService deleteUnitService)
    {
        _getUnitService = getUnitService;
        _createUnitService = createUnitService;
        _updateUnitService = updateUnitService;
        _deleteUnitService = deleteUnitService;
    }

    /// <summary>
    /// Get unit of measurements
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getUnitService.GetUnitsAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get unit of measurement by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getUnitService.GetUnitAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new unit of measurement
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateUnitDto model)
    {
        await _createUnitService.CreateUnitAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a unit of measurement
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut()]
    public async Task<IActionResult> Put(UpdateUnitDto model)
    {
        await _updateUnitService.UpdateUnitAsync(model);
        return NoContent();
    }

    /// <summary>
    /// Delete a unit of measurement
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteUnitService.DeleteUnitAsync(id);
        return NoContent();
    }
}