using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.Inventory.Category;
using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// Categorys endpoints
/// </summary>
[ApiController()]
[Route("api/inventory/categories")]
public class CategoriesController : ControllerBase
{
    private readonly IGetCategoryService _getCategoryService;
    private readonly ICreateCategoryService _createCategoryService;
    private readonly IUpdateCategoryService _updateCategoryService;
    private readonly IDeleteCategoryService _deleteCategoryService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="getCategoryService"></param>
    /// <param name="createCategoryService"></param>
    /// <param name="updateCategoryService"></param>
    /// <param name="deleteCategoryService"></param>
    public CategoriesController(
        IGetCategoryService getCategoryService,
        ICreateCategoryService createCategoryService,
        IUpdateCategoryService updateCategoryService,
        IDeleteCategoryService deleteCategoryService)
    {
        _getCategoryService = getCategoryService;
        _createCategoryService = createCategoryService;
        _updateCategoryService = updateCategoryService;
        _deleteCategoryService = deleteCategoryService;
    }

    /// <summary>
    /// Get Categories
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getCategoryService.GetCategoriesAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get category by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getCategoryService.GetCategoryAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new category
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateCategoryDto model)
    {
        await _createCategoryService.CreateCategoryAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateCategoryDto model)
    {
        await _updateCategoryService.UpdateCategoryAsync(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteCategoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}