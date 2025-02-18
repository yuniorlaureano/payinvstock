namespace Payinvstock.Contract.Dal.Inventory.Stock;

public interface IUpdateStockRepo
{
    Task UpdateStockAsync(Entity.Inventory.Stock model);
}