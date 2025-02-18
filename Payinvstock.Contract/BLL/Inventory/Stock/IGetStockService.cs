using Payinvstock.Contract.Dal.Inventory.Stock;
using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Contract.BLL.Inventory.Stock;

public interface IGetStockService
{
    Task<IEnumerable<GetStockDto>> GetStocksAsync();

    Task<GetStockDto?> GetStockAsync(Guid id);
}