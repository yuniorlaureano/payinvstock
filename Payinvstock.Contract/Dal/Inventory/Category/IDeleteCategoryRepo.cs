namespace Payinvstock.Contract.Dal.Inventory.Category;

public interface IDeleteCategoryRepo
{
    Task DeleteCategoryAsync(Guid id);
}
