namespace Payinvstock.Contract.Dal.Inventory.Product;

public interface IUpdateProductRepo
{
    /// <summary>
    /// Update a product in the database
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task UpdateProductAsync(Entity.Inventory.Product product);
}