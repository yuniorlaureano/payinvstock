namespace Payinvstock.Contract.Dal.Inventory.Product;

public interface ICreateProductRepo
{
    Task CreateProductAsync(Entity.Inventory.Product product);
}