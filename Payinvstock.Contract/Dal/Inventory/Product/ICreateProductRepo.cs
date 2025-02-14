namespace Payinvstock.Contract.Dal.Inventory.Product;

public interface ICreateProductRepo
{
    /// <summary>
    /// Create a product in the database
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task CreateProductAsync(Entity.Inventory.Product product);
}