using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Contract.BLL.Inventory.Stock;

public interface IGetStockService
{
    Task<IEnumerable<GetStockDto>> GetStocksAsync();

    Task<GetSingleStockDto?> GetStockAsync(Guid id);
}