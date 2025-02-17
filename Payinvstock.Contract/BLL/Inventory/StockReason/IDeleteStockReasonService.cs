namespace Payinvstock.Contract.BLL.Inventory.StockReason;

public interface IDeleteStockReasonService
{
    Task DeleteStockReasonAsync(Guid id);
}