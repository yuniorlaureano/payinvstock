using Payinvstock.Dto.Inventory.Product;

namespace Payinvstock.Contract.BLL.Inventory.Product;

public interface IGetProductService
{
    Task<IEnumerable<GetProductDto>> GetProductsAsync();
    Task<GetProductDto?> GetProductAsync(Guid id);
}