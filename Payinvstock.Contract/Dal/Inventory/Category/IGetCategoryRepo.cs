namespace Payinvstock.Contract.Dal.Inventory.Category;

public interface IGetCategoryRepo
{
    Task<IEnumerable<Entity.Inventory.Category>> GetCategoriesAsync();
    Task<Entity.Inventory.Category?> GetCategoryAsync(Guid id);
}
