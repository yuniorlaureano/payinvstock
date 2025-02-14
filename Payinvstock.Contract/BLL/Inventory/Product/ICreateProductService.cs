using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Contract.BLL.Inventory.Product;

public interface ICreateProductService
{
    Task CreateProductAsync(CreateProductDto model);
}