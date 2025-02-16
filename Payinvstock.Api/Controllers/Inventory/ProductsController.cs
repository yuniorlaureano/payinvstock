using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// Products endpoints
/// </summary>
[ApiController()]
[Route("api/inventory/products")]
public class ProductsController : ControllerBase
{
    private readonly IGetProductService _getProductService;
    private readonly ICreateProductService _createProductService;
    private readonly IUpdateProductService _updateProductService;
    private readonly IDeleteProductService _deleteProductService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="getProductService"></param>
    /// <param name="createProductService"></param>
    /// <param name="updateProductService"></param>
    /// <param name="deleteProductService"></param>
    public ProductsController(
        IGetProductService getProductService,
        ICreateProductService createProductService,
        IUpdateProductService updateProductService,
        IDeleteProductService deleteProductService)
    {
        _getProductService = getProductService;
        _createProductService = createProductService;
        _updateProductService = updateProductService;
        _deleteProductService = deleteProductService;
    }

    /// <summary>
    /// Get products
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var result = await _getProductService.GetProductsAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _getProductService.GetProductAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(CreateProductDto model)
    {
        await _createProductService.CreateProductAsync(model);
        return Created();
    }

    /// <summary>
    /// Update a product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateProductDto model)
    {
        await _updateProductService.UpdateProductAsync(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteProductService.DeleteProductAsync(id);
        return NoContent();
    }
}