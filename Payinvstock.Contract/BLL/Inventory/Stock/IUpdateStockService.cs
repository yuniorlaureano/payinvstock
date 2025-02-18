using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Contract.BLL.Inventory.Stock;

public interface IUpdateStockService
{
    Task UpdateStockAsync(Guid id, UpdateStockDto model);
}