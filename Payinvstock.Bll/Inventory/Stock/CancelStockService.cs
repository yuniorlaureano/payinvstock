using Payinvstock.Contract.BLL.Inventory.Stock;
using Payinvstock.Contract.Dal.Inventory.Stock;
using Payinvstock.Contract.Util.Http;

namespace Payinvstock.Bll.Inventory.Stock;

public class CancelStockService : ICancelStockService
{
    private readonly ICancelStockRepo _cancelStockRepo;
    private readonly IGetStockRepo _getStockRepo;
    private readonly IUserHttpContextAccessor _userContextAccessor;

    public CancelStockService(
        ICancelStockRepo cancelStockRepo,
        IGetStockRepo getStockRepo,
        IUserHttpContextAccessor userContextAccessor)
    {
        _cancelStockRepo = cancelStockRepo;
        _getStockRepo = getStockRepo;
        _userContextAccessor = userContextAccessor;
    }

    public async Task CancelStockAsync(Guid id)
    {
        var entity = await _getStockRepo.GetStockAsync(id);
        if (entity is null)
        {
            return;
        }

        entity.UpdatedBy = _userContextAccessor.GetCurrentUserId();
        await _cancelStockRepo.UpdateStockAsync(entity);
    }

}