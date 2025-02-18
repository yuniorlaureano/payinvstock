namespace Payinvstock.Contract.Dal.Inventory.Stock;

public interface ICreateStockRepo
{
    Task CreateStockAsync(Entity.Inventory.Stock model, List<Entity.Inventory.StockDetail> detail);
}