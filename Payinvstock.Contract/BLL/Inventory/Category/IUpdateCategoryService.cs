using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Contract.BLL.Inventory.Category;

public interface IUpdateCategoryService
{
    Task<GetCategoryDto?> UpdateCategoryAsync(Guid id, UpdateCategoryDto model);
}