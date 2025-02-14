namespace Payinvstock.Contract.Dal.Inventory.Product;

public interface IGetProductRepo
{
    /// <summary>
    /// Get products from db
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Entity.Inventory.Product>> GetProductsAsync();

    /// <summary>
    /// Get product by Id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<Entity.Inventory.Product?> GetProductAsync(Guid id);
}