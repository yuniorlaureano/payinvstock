namespace Payinvstock.Contract.Dal.Inventory.Product;

public interface IDeleteProductRepo
{
    /// <summary>
    /// Delete a product in the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteProductAsync(Guid id);
}