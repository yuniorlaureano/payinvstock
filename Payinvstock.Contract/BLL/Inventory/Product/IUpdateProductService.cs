using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Contract.BLL.Inventory.Product;

public interface IUpdateProductService
{
    Task<GetProductDto?> UpdateProductAsync(Guid id, UpdateProductDto model);
}