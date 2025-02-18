namespace Payinvstock.Contract.Dal.Inventory.Stock;

public interface IDeleteStockRepo
{
    Task DeleteStockAsync(Guid id);
}