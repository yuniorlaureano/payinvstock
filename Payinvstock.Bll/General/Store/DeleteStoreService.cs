using Payinvstock.Contract.BLL.General.Store;
using Payinvstock.Contract.Dal.General.Store;

namespace Payinvstock.Bll.General.Store;

public class DeleteStoreService : IDeleteStoreService
{
    private readonly IDeleteStoreRepo _deleteStoreRepo;

    public DeleteStoreService(IDeleteStoreRepo deleteStoreRepo)
    {
        _deleteStoreRepo = deleteStoreRepo;
    }

    public async Task DeleteStoreAsync(Guid id)
    {
        await _deleteStoreRepo.DeleteStoreAsync(id);
    }
}