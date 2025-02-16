using Payinvstock.Contract.BLL.Inventory.Category;
using Payinvstock.Contract.Dal.Inventory.Category;

namespace Payinvstock.Bll.Inventory.Category;

public class DeleteCategoryService : IDeleteCategoryService
{
    private readonly IDeleteCategoryRepo _deleteCategoryRepo;

    public DeleteCategoryService(IDeleteCategoryRepo deleteCategoryRepo)
    {
        _deleteCategoryRepo = deleteCategoryRepo;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await _deleteCategoryRepo.DeleteCategoryAsync(id);
    }
}