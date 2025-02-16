namespace Payinvstock.Contract.Dal.Inventory.Category;

public interface ICreateCategoryRepo
{
    Task CreateCategoryAsync(Entity.Inventory.Category model);
}
