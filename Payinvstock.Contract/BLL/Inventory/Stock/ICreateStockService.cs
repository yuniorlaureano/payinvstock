using Payinvstock.Dto.Inventory.Stock;
using Payinvstock.Common.Exceptions;

namespace Payinvstock.Contract.BLL.Inventory.Stock;

public interface ICreateStockService
{

    /// <summary>
    /// Create a new stock
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="InvalidStockException"></exception>
    Task CreateStockAsync(CreateStockDto createStockDto);
}