using Payinvstock.Dto.Inventory.Stock;

namespace Payinvstock.Contract.BLL.Inventory.Stock;

public interface ICreateStockService
{
    Task CreateStockAsync(CreateStockDto createStockDto);
}