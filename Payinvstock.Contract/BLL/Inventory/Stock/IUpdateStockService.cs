using Payinvstock.Dto.Inventory.Stock;
using Payinvstock.Common.Exceptions;

namespace Payinvstock.Contract.BLL.Inventory.Stock;


public interface IUpdateStockService
{
    /// <summary>
    /// Update stock
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="InvalidStatusException">Thrown when the status is Saved, and an attempt is made to change is to Draft or Cancelled</exception>
    Task UpdateStockAsync(Guid id, UpdateStockDto model);
}