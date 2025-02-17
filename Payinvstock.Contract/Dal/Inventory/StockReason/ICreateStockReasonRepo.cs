namespace Payinvstock.Contract.Dal.Inventory.StockReason;

public interface ICreateStockReasonRepo
{
    Task CreateStockReasonAsync(Entity.Inventory.StockReason model);
}
