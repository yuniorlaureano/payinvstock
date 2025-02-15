using Payinvstock.Contract.BLL.General.Unit;
using Payinvstock.Contract.Dal.General.Unit;

namespace Payinvstock.Bll.General.Unit;

public class DeleteUnitService : IDeleteUnitService
{
    private readonly IDeleteUnitRepo _deleteUnitRepo;

    public DeleteUnitService(IDeleteUnitRepo deleteUnitRepo)
    {
        _deleteUnitRepo = deleteUnitRepo;
    }

    public async Task DeleteUnitAsync(Guid id)
    {
        await _deleteUnitRepo.DeleteUnitAsync(id);
    }
}