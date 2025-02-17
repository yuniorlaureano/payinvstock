namespace Payinvstock.Contract.Dal.Inventory.StockReason;

public interface IDeleteStockReasonRepo
{
    Task DeleteStockReasonAsync(Guid id);
}
