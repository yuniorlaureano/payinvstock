using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Contract.BLL.Inventory.Product;

public interface IUpdateProductService
{
    Task UpdateProductAsync(UpdateProductDto model);
}