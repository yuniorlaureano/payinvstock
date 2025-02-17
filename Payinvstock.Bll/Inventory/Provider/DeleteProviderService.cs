using Payinvstock.Contract.BLL.Inventory.Provider;
using Payinvstock.Contract.Dal.Inventory.Provider;

namespace Payinvstock.Bll.Inventory.Provider;

public class DeleteProviderService : IDeleteProviderService
{
    private readonly IDeleteProviderRepo _deleteProviderRepo;

    public DeleteProviderService(IDeleteProviderRepo deleteProviderRepo)
    {
        _deleteProviderRepo = deleteProviderRepo;
    }

    public async Task DeleteProviderAsync(Guid id)
    {
        await _deleteProviderRepo.DeleteProviderAsync(id);
    }
}