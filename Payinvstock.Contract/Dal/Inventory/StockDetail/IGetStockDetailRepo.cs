namespace Payinvstock.Contract.Dal.Inventory.StockDetail;

public interface IGetStockDetailRepo
{
    Task<IEnumerable<Entity.Inventory.StockDetail>> GetStockDetailByStockIdAsync(Guid stockId);
}