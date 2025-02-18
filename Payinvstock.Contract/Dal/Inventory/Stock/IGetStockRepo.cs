namespace Payinvstock.Contract.Dal.Inventory.Stock;

public interface IGetStockRepo
{
    Task<IEnumerable<Entity.Inventory.Stock>> GetStocksAsync();
    Task<Entity.Inventory.Stock?> GetStockAsync(Guid id);

}