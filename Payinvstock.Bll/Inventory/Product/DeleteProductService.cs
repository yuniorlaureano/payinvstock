using Payinvstock.Contract.BLL.Inventory.Product;
using Payinvstock.Contract.Dal.Inventory.Product;

namespace Payinvstock.Bll.Inventory.Product;

public class DeleteProductService : IDeleteProductService
{
    private readonly IDeleteProductRepo _deleteProductRepo;

    public DeleteProductService(IDeleteProductRepo deleteProductRepo)
    {
        _deleteProductRepo = deleteProductRepo;
    }

    public async Task DeleteProductAsync(Guid id)
    {
        await _deleteProductRepo.DeleteProductAsync(id);
    }
}