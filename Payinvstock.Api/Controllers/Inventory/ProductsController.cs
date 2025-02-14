using Microsoft.AspNetCore.Mvc;
using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Api.Controllers.Inventory;

/// <summary>
/// Products endpoints
/// Allow to manage products
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
    /// Get all products
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var products = await _getProductService.GetProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _getProductService.GetProductAsync(id);
        return Ok(product);
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
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut()]
    public async Task<IActionResult> Put(UpdateProductDto model)
    {
        await _updateProductService.UpdateProductAsync(model);
        return NoContent();
    }

    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteProductService.DeleteProductAsync(id);
        return NoContent();
    }
}