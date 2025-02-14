namespace Payinvstock.Contract.BLL.Inventory.Product;

public interface IDeleteProductService
{
    Task DeleteProductAsync(Guid id);
}