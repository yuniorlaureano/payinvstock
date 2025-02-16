using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Contract.BLL.Inventory.Category;

public interface IGetCategoryService
{
    Task<IEnumerable<GetCategoryDto>> GetCategoriesAsync();
    Task<GetCategoryDto?> GetCategoryAsync(Guid id);
}