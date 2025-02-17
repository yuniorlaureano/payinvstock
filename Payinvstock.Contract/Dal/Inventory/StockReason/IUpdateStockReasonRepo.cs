namespace Payinvstock.Contract.Dal.Inventory.StockReason;

public interface IUpdateStockReasonRepo
{
    Task UpdateStockReasonAsync(Entity.Inventory.StockReason model);
}
