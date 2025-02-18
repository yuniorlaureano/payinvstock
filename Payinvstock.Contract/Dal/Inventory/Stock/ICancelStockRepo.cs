namespace Payinvstock.Contract.Dal.Inventory.Stock;

public interface ICancelStockRepo
{
    Task UpdateStockAsync(Entity.Inventory.Stock model);
}