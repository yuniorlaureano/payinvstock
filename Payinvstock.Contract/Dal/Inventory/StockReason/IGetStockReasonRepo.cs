namespace Payinvstock.Contract.Dal.Inventory.StockReason;

public interface IGetStockReasonRepo
{
    Task<IEnumerable<Entity.Inventory.StockReason>> GetStockReasonsAsync();
    Task<Entity.Inventory.StockReason?> GetStockReasonAsync(Guid id);
}
