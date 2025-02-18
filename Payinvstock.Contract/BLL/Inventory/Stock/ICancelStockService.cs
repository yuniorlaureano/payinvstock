namespace Payinvstock.Contract.BLL.Inventory.Stock;

public interface ICancelStockService
{
    Task CancelStockAsync(Guid id);
}