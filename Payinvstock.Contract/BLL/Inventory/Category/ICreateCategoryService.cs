using Payinvstock.Dto.Inventory.Category;

namespace Payinvstock.Contract.BLL.Inventory.Category;

public interface ICreateCategoryService
{
    Task CreateCategoryAsync(CreateCategoryDto model);
}