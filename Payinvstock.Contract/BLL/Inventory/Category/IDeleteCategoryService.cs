namespace Payinvstock.Contract.BLL.Inventory.Category;

public interface IDeleteCategoryService
{
    Task DeleteCategoryAsync(Guid id);
}