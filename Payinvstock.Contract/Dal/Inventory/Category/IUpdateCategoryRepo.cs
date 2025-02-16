namespace Payinvstock.Contract.Dal.Inventory.Category;

public interface IUpdateCategoryRepo
{
    Task UpdateCategoryAsync(Entity.Inventory.Category model);
}
